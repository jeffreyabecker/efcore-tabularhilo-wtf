CREATE TABLE IF NOT EXISTS "__EFCoreHiLoSequences" (
    "SequenceName" TEXT NOT NULL CONSTRAINT "PK___EFCoreHiLoSequences" PRIMARY KEY,
    "CurrentValue" INTEGER NOT NULL,
    "IncrementBy" INTEGER NOT NULL
);
CREATE TABLE "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "__EFCoreHiLoSequences" (
    "SequenceName" TEXT NOT NULL CONSTRAINT "PK___EFCoreHiLoSequences" PRIMARY KEY,
    "CurrentValue" INTEGER NOT NULL,
    "IncrementBy" INTEGER NOT NULL
);

CREATE TABLE "Blogs" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Blogs" PRIMARY KEY AUTOINCREMENT,
    "Url" TEXT NOT NULL
);

CREATE TABLE "Posts" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Posts" PRIMARY KEY AUTOINCREMENT,
    "Title" TEXT NOT NULL,
    "Content" TEXT NOT NULL,
    "BlogId" INTEGER NOT NULL,
    CONSTRAINT "FK_Posts_Blogs_BlogId" FOREIGN KEY ("BlogId") REFERENCES "Blogs" ("Id") ON DELETE CASCADE
);

INSERT INTO "__EFCoreHiLoSequences" ("SequenceName", "CurrentValue", "IncrementBy")
VALUES ('Blog', 1, 10);
INSERT INTO "__EFCoreHiLoSequences" ("SequenceName", "CurrentValue", "IncrementBy")
VALUES ('Post', 1, 10);

CREATE INDEX "IX_Posts_BlogId" ON "Posts" ("BlogId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230911163442_InitialCreate', '7.0.10');

COMMIT;


