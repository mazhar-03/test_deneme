CREATE TABLE Product(
    ID INT PRIMARY KEY IDENTITY(1,1),
    NAME NVARCHAR(100) NOT NULL,
    PRICE FLOAT(3) NOT NULL
)

CREATE TABLE Category(
                         ID INT PRIMARY KEY IDENTITY(1,1),
                         NAME NVARCHAR(100) NOT NULL
)

CREATE TABLE Product_Category (
                                  Product_Id INT,
                                  Category_Id INT,
                                  PRIMARY KEY (Product_Id, Category_Id),
                                  FOREIGN KEY (Product_Id) REFERENCES Product(Id) ON DELETE CASCADE,
                                  FOREIGN KEY (Category_Id) REFERENCES Category(Id) ON DELETE CASCADE
);