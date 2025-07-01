alter table cart add constraint FK_Cart_UserFID
foreign key (UserFID) REFERENCES Users (UserId)
on delete cascade