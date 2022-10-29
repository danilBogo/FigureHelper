SELECT Products.product_name, Categories.category_name 
FROM Products 
LEFT JOIN ProductCategory ON Products.product_id = ProductCategory.product_id 
LEFT JOIN Categories ON ProductCategory.category_id = Categories.category_id;