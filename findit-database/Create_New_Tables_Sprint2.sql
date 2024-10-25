use FindIt

-- create new tables:
create table ShoppingCarts(
	CartID				uniqueidentifier	NOT NULL PRIMARY KEY DEFAULT NewID(),
	UserID				uniqueidentifier	NOT NULL FOREIGN KEY REFERENCES Users(UserID) ON DELETE CASCADE
);

create table ProductsInCart(
	CartID				uniqueidentifier	NOT NULL FOREIGN KEY REFERENCES ShoppingCarts(CartID) ON DELETE CASCADE,
	ProductID			uniqueidentifier	NOT NULL FOREIGN KEY REFERENCES Products(ProductID) ON DELETE CASCADE,
	Quantity			int					NOT NULL
);
