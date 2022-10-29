CREATE TABLE Products
( product_id INT NOT NULL,
  product_name CHAR(50) NOT NULL,
  CONSTRAINT products_pk PRIMARY KEY (product_id)
);
CREATE TABLE Categories
( category_id INT NOT NULL,
  category_name CHAR(50) NOT NULL,
  CONSTRAINT category_pk PRIMARY KEY (category_id)
);
CREATE TABLE ProductCategory
( product_category_id INT NOT NULL,
  product_id INT,
  category_id INT,
  CONSTRAINT product_category_pk PRIMARY KEY (product_category_id),
  CONSTRAINT products_fk FOREIGN KEY (product_id) REFERENCES Products(product_id),
  CONSTRAINT categories_fk FOREIGN KEY (category_id) REFERENCES Categories(category_id)
);
 
INSERT INTO Products(product_id, product_name) VALUES(1, 'product1');
INSERT INTO Products(product_id, product_name) VALUES(2, 'product2');
INSERT INTO Products(product_id, product_name) VALUES(3, 'product3');
 
INSERT INTO Categories(category_id, category_name) VALUES(1, 'category1');
INSERT INTO Categories(category_id, category_name) VALUES(2, 'category2');
INSERT INTO Categories(category_id, category_name) VALUES(3, 'category3');
 
INSERT INTO ProductCategory(product_category_id, product_id, category_id) VALUES(1, 1, 1);
INSERT INTO ProductCategory(product_category_id, product_id, category_id) VALUES(2, 1, 2);
INSERT INTO ProductCategory(product_category_id, product_id, category_id) VALUES(3, 1, 3);
INSERT INTO ProductCategory(product_category_id, product_id, category_id) VALUES(4, 2, 1);
 
SELECT Products.product_name, Categories.category_name 
FROM Products 
LEFT JOIN ProductCategory ON Products.product_id = ProductCategory.product_id 
LEFT JOIN Categories ON ProductCategory.category_id = Categories.category_id;