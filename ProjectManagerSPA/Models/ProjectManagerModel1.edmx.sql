
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/28/2019 23:50:26
-- Generated from EDMX file: C:\Users\Admin\Documents\Visual Studio 2017\Projects\ProjectManagerSPA\ProjectManagerSPA\Models\ProjectManagerModel1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TaskManager];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [FK_UserProject];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_UserTask];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_ProjectTask];
GO
IF OBJECT_ID(N'[dbo].[FK_ParentTaskTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_ParentTaskTask];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectParentTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParentTasks] DROP CONSTRAINT [FK_ProjectParentTask];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[Tasks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tasks];
GO
IF OBJECT_ID(N'[dbo].[ParentTasks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParentTasks];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [EmployeeID] nvarchar(max)  NOT NULL,
    [ProjectID] nvarchar(max)  NULL,
    [TaskID] nvarchar(max)  NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [ProjectID] int IDENTITY(1,1) NOT NULL,
    [ProjectName] nvarchar(max)  NOT NULL,
    [StartDate] nvarchar(max)  NOT NULL,
    [EndDate] nvarchar(max)  NOT NULL,
    [Priority] nvarchar(max)  NOT NULL,
    [ManagerUserId] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tasks'
CREATE TABLE [dbo].[Tasks] (
    [TaskID] int IDENTITY(1,1) NOT NULL,
    [ParentID] nvarchar(max)  NOT NULL,
    [ProjectID] nvarchar(max)  NOT NULL,
    [TaskName] nvarchar(max)  NOT NULL,
    [StartDate] nvarchar(max)  NOT NULL,
    [EndDate] nvarchar(max)  NOT NULL,
    [Priority] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [UserID] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ParentTasks'
CREATE TABLE [dbo].[ParentTasks] (
    [ParentID] int IDENTITY(1,1) NOT NULL,
    [ParentTaskName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [ProjectID] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([ProjectID] ASC);
GO

-- Creating primary key on [TaskID] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [PK_Tasks]
    PRIMARY KEY CLUSTERED ([TaskID] ASC);
GO

-- Creating primary key on [ParentID] in table 'ParentTasks'
ALTER TABLE [dbo].[ParentTasks]
ADD CONSTRAINT [PK_ParentTasks]
    PRIMARY KEY CLUSTERED ([ParentID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------