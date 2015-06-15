
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/14/2015 22:50:45
-- Generated from EDMX file: C:\Users\medjo_000\Documents\Visual Studio 2013\Projects\WebApplication1\WebApplication1\Models\DAL\TemsTNTUDataContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TemsTNTU];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_report_artist]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[report] DROP CONSTRAINT [FK_report_artist];
GO
IF OBJECT_ID(N'[dbo].[FK_report_card_report]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[report_card] DROP CONSTRAINT [FK_report_card_report];
GO
IF OBJECT_ID(N'[dbo].[FK_stage_state_topic]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[stage] DROP CONSTRAINT [FK_stage_state_topic];
GO
IF OBJECT_ID(N'[dbo].[FK_id_degree]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[artist] DROP CONSTRAINT [FK_id_degree];
GO
IF OBJECT_ID(N'[dbo].[FK_id_post]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[artist] DROP CONSTRAINT [FK_id_post];
GO
IF OBJECT_ID(N'[dbo].[FK_id_rank]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[artist] DROP CONSTRAINT [FK_id_rank];
GO
IF OBJECT_ID(N'[dbo].[FK_id_st]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[artist] DROP CONSTRAINT [FK_id_st];
GO
IF OBJECT_ID(N'[dbo].[FK_id_stage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[report] DROP CONSTRAINT [FK_id_stage];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[artist]', 'U') IS NOT NULL
    DROP TABLE [dbo].[artist];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[degree]', 'U') IS NOT NULL
    DROP TABLE [dbo].[degree];
GO
IF OBJECT_ID(N'[dbo].[post]', 'U') IS NOT NULL
    DROP TABLE [dbo].[post];
GO
IF OBJECT_ID(N'[dbo].[rank]', 'U') IS NOT NULL
    DROP TABLE [dbo].[rank];
GO
IF OBJECT_ID(N'[dbo].[report]', 'U') IS NOT NULL
    DROP TABLE [dbo].[report];
GO
IF OBJECT_ID(N'[dbo].[report_card]', 'U') IS NOT NULL
    DROP TABLE [dbo].[report_card];
GO
IF OBJECT_ID(N'[dbo].[stage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[stage];
GO
IF OBJECT_ID(N'[dbo].[state_topic]', 'U') IS NOT NULL
    DROP TABLE [dbo].[state_topic];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'artist'
CREATE TABLE [dbo].[artist] (
    [id_artist] nvarchar(128)  NOT NULL,
    [PIB] nvarchar(255)  NULL,
    [id_degree] int  NULL,
    [id_rank] int  NULL,
    [id_post] int  NULL,
    [diploma] nvarchar(255)  NULL,
    [date_diploma] nvarchar(255)  NULL,
    [certificate] nvarchar(255)  NULL,
    [date_certificate] nvarchar(255)  NULL,
    [id_st] int  NULL,
    [id_stage] int  NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'degree'
CREATE TABLE [dbo].[degree] (
    [id_degree] int IDENTITY(1,1) NOT NULL,
    [title] nvarchar(255)  NOT NULL,
    [surcharge] float  NOT NULL
);
GO

-- Creating table 'post'
CREATE TABLE [dbo].[post] (
    [id_post] int IDENTITY(1,1) NOT NULL,
    [title] nvarchar(255)  NOT NULL,
    [salary] float  NOT NULL
);
GO

-- Creating table 'rank'
CREATE TABLE [dbo].[rank] (
    [id_rank] int IDENTITY(1,1) NOT NULL,
    [surcharge] float  NOT NULL,
    [title] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'report'
CREATE TABLE [dbo].[report] (
    [id_report] int IDENTITY(1,1) NOT NULL,
    [id_artist] nvarchar(128)  NOT NULL,
    [id_stage] int  NOT NULL,
    [stage] varchar(max)  NOT NULL
);
GO

-- Creating table 'report_card'
CREATE TABLE [dbo].[report_card] (
    [id_rc] int IDENTITY(1,1) NOT NULL,
    [id_report] int  NOT NULL,
    [fees] float  NOT NULL,
    [number] int  NOT NULL,
    [main_job] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'stage'
CREATE TABLE [dbo].[stage] (
    [id_stage] int IDENTITY(1,1) NOT NULL,
    [number] int  NOT NULL,
    [time_begin] nvarchar(255)  NOT NULL,
    [title] nvarchar(255)  NOT NULL,
    [type_end_value] nvarchar(max)  NOT NULL,
    [id_st] int  NOT NULL,
    [time_end] nvarchar(255)  NULL,
    [id_artist] nvarchar(128)  NULL
);
GO

-- Creating table 'state_topic'
CREATE TABLE [dbo].[state_topic] (
    [id_st] int IDENTITY(1,1) NOT NULL,
    [budget] float  NOT NULL,
    [time_begin] nvarchar(255)  NOT NULL,
    [title] nvarchar(255)  NOT NULL,
    [time_end] nvarchar(255)  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'artiststage'
CREATE TABLE [dbo].[artiststage] (
    [artist_id_artist] nvarchar(128)  NOT NULL,
    [stage_id_stage] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [id_artist] in table 'artist'
ALTER TABLE [dbo].[artist]
ADD CONSTRAINT [PK_artist]
    PRIMARY KEY CLUSTERED ([id_artist] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id_degree] in table 'degree'
ALTER TABLE [dbo].[degree]
ADD CONSTRAINT [PK_degree]
    PRIMARY KEY CLUSTERED ([id_degree] ASC);
GO

-- Creating primary key on [id_post] in table 'post'
ALTER TABLE [dbo].[post]
ADD CONSTRAINT [PK_post]
    PRIMARY KEY CLUSTERED ([id_post] ASC);
GO

-- Creating primary key on [id_rank] in table 'rank'
ALTER TABLE [dbo].[rank]
ADD CONSTRAINT [PK_rank]
    PRIMARY KEY CLUSTERED ([id_rank] ASC);
GO

-- Creating primary key on [id_report] in table 'report'
ALTER TABLE [dbo].[report]
ADD CONSTRAINT [PK_report]
    PRIMARY KEY CLUSTERED ([id_report] ASC);
GO

-- Creating primary key on [id_rc] in table 'report_card'
ALTER TABLE [dbo].[report_card]
ADD CONSTRAINT [PK_report_card]
    PRIMARY KEY CLUSTERED ([id_rc] ASC);
GO

-- Creating primary key on [id_stage] in table 'stage'
ALTER TABLE [dbo].[stage]
ADD CONSTRAINT [PK_stage]
    PRIMARY KEY CLUSTERED ([id_stage] ASC);
GO

-- Creating primary key on [id_st] in table 'state_topic'
ALTER TABLE [dbo].[state_topic]
ADD CONSTRAINT [PK_state_topic]
    PRIMARY KEY CLUSTERED ([id_st] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- Creating primary key on [artist_id_artist], [stage_id_stage] in table 'artiststage'
ALTER TABLE [dbo].[artiststage]
ADD CONSTRAINT [PK_artiststage]
    PRIMARY KEY CLUSTERED ([artist_id_artist], [stage_id_stage] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [id_artist] in table 'report'
ALTER TABLE [dbo].[report]
ADD CONSTRAINT [FK_report_artist]
    FOREIGN KEY ([id_artist])
    REFERENCES [dbo].[artist]
        ([id_artist])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_report_artist'
CREATE INDEX [IX_FK_report_artist]
ON [dbo].[report]
    ([id_artist]);
GO

-- Creating foreign key on [id_degree] in table 'artist'
ALTER TABLE [dbo].[artist]
ADD CONSTRAINT [FK_id_degree]
    FOREIGN KEY ([id_degree])
    REFERENCES [dbo].[degree]
        ([id_degree])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_id_degree'
CREATE INDEX [IX_FK_id_degree]
ON [dbo].[artist]
    ([id_degree]);
GO

-- Creating foreign key on [id_post] in table 'artist'
ALTER TABLE [dbo].[artist]
ADD CONSTRAINT [FK_id_post]
    FOREIGN KEY ([id_post])
    REFERENCES [dbo].[post]
        ([id_post])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_id_post'
CREATE INDEX [IX_FK_id_post]
ON [dbo].[artist]
    ([id_post]);
GO

-- Creating foreign key on [id_rank] in table 'artist'
ALTER TABLE [dbo].[artist]
ADD CONSTRAINT [FK_id_rank]
    FOREIGN KEY ([id_rank])
    REFERENCES [dbo].[rank]
        ([id_rank])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_id_rank'
CREATE INDEX [IX_FK_id_rank]
ON [dbo].[artist]
    ([id_rank]);
GO

-- Creating foreign key on [id_st] in table 'artist'
ALTER TABLE [dbo].[artist]
ADD CONSTRAINT [FK_id_st]
    FOREIGN KEY ([id_st])
    REFERENCES [dbo].[state_topic]
        ([id_st])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_id_st'
CREATE INDEX [IX_FK_id_st]
ON [dbo].[artist]
    ([id_st]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [id_rc] in table 'report_card'
ALTER TABLE [dbo].[report_card]
ADD CONSTRAINT [FK_report_card_report]
    FOREIGN KEY ([id_rc])
    REFERENCES [dbo].[report]
        ([id_report])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id_stage] in table 'report'
ALTER TABLE [dbo].[report]
ADD CONSTRAINT [FK_id_stage]
    FOREIGN KEY ([id_stage])
    REFERENCES [dbo].[stage]
        ([id_stage])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_id_stage'
CREATE INDEX [IX_FK_id_stage]
ON [dbo].[report]
    ([id_stage]);
GO

-- Creating foreign key on [id_stage] in table 'stage'
ALTER TABLE [dbo].[stage]
ADD CONSTRAINT [FK_stage_state_topic]
    FOREIGN KEY ([id_stage])
    REFERENCES [dbo].[state_topic]
        ([id_st])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [artist_id_artist] in table 'artiststage'
ALTER TABLE [dbo].[artiststage]
ADD CONSTRAINT [FK_artiststage_artist]
    FOREIGN KEY ([artist_id_artist])
    REFERENCES [dbo].[artist]
        ([id_artist])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [stage_id_stage] in table 'artiststage'
ALTER TABLE [dbo].[artiststage]
ADD CONSTRAINT [FK_artiststage_stage]
    FOREIGN KEY ([stage_id_stage])
    REFERENCES [dbo].[stage]
        ([id_stage])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_artiststage_stage'
CREATE INDEX [IX_FK_artiststage_stage]
ON [dbo].[artiststage]
    ([stage_id_stage]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------