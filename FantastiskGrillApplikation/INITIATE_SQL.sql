CREATE TABLE [dbo].[Tbl_Menu] (
[Me_Id]	INT	IDENTITY (1,1) NOT NULL,
[Me_Name] VARCHAR(320) NULL,
[Me_Price] INT NOT NULL,
[Me_Type] VARCHAR(320) NOT NULL,
[Me_IsSpecialPrice] INT NOT NULL,

CONSTRAINT [PK_Tbl_Menu] PRIMARY KEY CLUSTERED ([Me_Id] ASC),
CONSTRAINT [Tbl_Menu_IsSpecialPrice] CHECK ([Me_IsSpecialPrice] >= 0 AND [Me_IsSpecialPrice] <= 1)
);

CREATE TABLE [dbo].[Tbl_Ingredient](
[In_Id] INT IDENTITY (1,1) NOT NULL,
[In_Name] VARCHAR(320) NOT NULL,
[In_Color] NVARCHAR(320) NOT NULL,

CONSTRAINT [PK_Tbl_Ingredient] PRIMARY KEY CLUSTERED ([In_Id] ASC)
);

CREATE TABLE [dbo].[Tbl_HasIngredient](
[HI_Id] INT IDENTITY (1,1) NOT NULL,
[HI_Me_Id] INT NOT NULL,
[HI_In_Id] INT NOT NULL,
[HI_Quantity] INT NOT NULL,

CONSTRAINT [PK_Tbl_HasIngredient] PRIMARY KEY CLUSTERED ([HI_Id] ASC),
CONSTRAINT [FK_Tbl_HasIngredient_Me_Id] FOREIGN KEY ([HI_Me_Id]) REFERENCES [dbo].[Tbl_Menu] ([Me_Id]),
CONSTRAINT [FK_Tbl_HasIngredient_In_Id] FOREIGN KEY ([HI_In_Id]) REFERENCES [dbo].[Tbl_Ingredient] ([In_Id]),
CONSTRAINT [PK_Tbl_HasIngredient_ReferenceNotUnique] UNIQUE NONCLUSTERED ([HI_Me_Id] ASC, [HI_In_Id] ASC)
);