[Back to README](../README.md)



# API Documentation - Sales Endpoint

## Overview
The `/api/Sale` endpoint processes sales transactions, applying business rules for discounts based on item quantity.

## Request
### HTTP Method: `POST`
### URL: `https://localhost:7181/api/Sale`

### Example Request
```bash
curl -X 'POST' \
  'https://localhost:7181/api/Sale' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "userId": "7fb51e5b-11d5-49b9-a74a-f79cb0d29700",
  "branch": "MAGALU",
  "products": [
    {
      "productId": "665bc19a-1d49-44d6-9dee-44c1f170f630",
      "quantity": 12
    },
    {
      "productId": "7bb12001-dfad-498e-bf1a-6f7f42a51ae6",
      "quantity": 1
    },
    {
      "productId": "56ad3846-ca1b-4406-a0f8-4befccf9258f",
      "quantity": 1
    },
    {
      "productId": "56944238-5ab5-45dd-a120-19d5db05b662",
      "quantity": 15
    },
    {
      "productId": "eb024b20-7173-438e-982b-97d219d2a472",
      "quantity": 1
    }
  ]
}'
```

⚠️ **IMPORTANT:** The productId is renew every time that you start the project and do a run docker composer. So, do you need to 
get the new ids from [api get products](/.doc/products-api.md)



## Business Rules
The system applies the following discount and restriction rules:

### **Discount Tiers**
- **4+ items** → 10% discount
- **10-20 items** → 20% discount

### **Restrictions**
- **Maximum limit**: A single product cannot exceed **20 units per sale**.
- **No discounts** for purchases below **4 items**.

## Business Logic Implementation
The discount logic is implemented within the `Sale` domain entity.

### **Discount Calculation Logic**
```csharp
public void CalculateTotal()
{
    TotalAmount = Items.Sum(item =>
    {
        if (item.Quantity > 20) // Restriction: max 20 items per product
        {
            throw new InvalidOperationException("Cannot sell more than 20 identical items.");
        }
        if (item.Quantity >= 10)
        {
            item.Discount = 0.20m; // 20% discount
        }
        else if (item.Quantity >= 4)
        {
            item.Discount = 0.10m; // 10% discount
        }
        else
        {
            item.Discount = 0m; // No discount
        }

        item.Total = item.Quantity * item.Product.Price * (1 - item.Discount);
        return item.Total;
    });
}
```

## Handling Process
The `SaleHandler` processes the request, validates it, and applies the business rules.

```csharp
public async Task<SaleResult> Handle(SaleCommand request, CancellationToken cancellationToken)
{
    await _saleValidator.ValidateAndThrowAsync(request, cancellationToken);
    return _mapper.Map<SaleResult>(await ProcessSaleAsync(request, cancellationToken));
}
```

## Error Handling
The system returns appropriate validation errors if the business rules are violated.

| Scenario | Response Code | Message |
|----------|--------------|---------|
| More than 20 identical items | `400 Bad Request` | "Cannot sell more than 20 identical items." |
| Product not found | `404 Not Found` | "sale item with id {productId} not found" |
| Invalid request format | `400 Bad Request` | "Validation failed." |

