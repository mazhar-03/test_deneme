INSERT INTO Product (Name, Price)
VALUES ('Laptop', 1200.00),
       ('Smartphone', 800.00),
       ('Tablet', 450.00),
       ('Smartwatch', 250.00);

INSERT INTO Category (Name)
VALUES ('Electronics'),
       ('Computers'),
       ('Mobile Devices'),
       ('Wearables');

INSERT INTO Product_Category (Product_Id, Category_Id)
VALUES (1, 1), 
       (1, 2); 

INSERT INTO Product_Category (Product_Id, Category_Id)
VALUES (2, 1),  
       (2, 3); 

INSERT INTO Product_Category (Product_Id, Category_Id)
VALUES (3, 1), 
       (3, 3); 

INSERT INTO Product_Category (Product_Id, Category_Id)
VALUES (4, 1), 
       (4, 4);  
