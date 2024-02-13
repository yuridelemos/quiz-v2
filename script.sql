IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Category] (
    [Id] int NOT NULL IDENTITY,
    [Name] NVARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Question] (
    [Id] int NOT NULL IDENTITY,
    [Body] NVARCHAR(250) NOT NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_Question] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Question_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id])
);
GO

CREATE TABLE [Answer] (
    [Id] int NOT NULL IDENTITY,
    [QuestionId] int NOT NULL,
    [AnswerOrder] INT NOT NULL,
    [Body] NVARCHAR(250) NOT NULL,
    [RightAnswer] BIT NOT NULL,
    CONSTRAINT [PK_Answer] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Answer_Question] FOREIGN KEY ([QuestionId]) REFERENCES [Question] ([Id])
);
GO

CREATE INDEX [IX_Answer_QuestionId] ON [Answer] ([QuestionId]);
GO

CREATE UNIQUE INDEX [IX_Category_Slug] ON [Category] ([Slug]);
GO

CREATE INDEX [IX_Question_CategoryId] ON [Question] ([CategoryId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240213161843_InitialCreation', N'8.0.1');
GO

COMMIT;
GO

