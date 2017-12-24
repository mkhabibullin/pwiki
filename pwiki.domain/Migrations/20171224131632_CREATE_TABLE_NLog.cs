using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace pwiki.domain.Migrations
{
    public partial class CREATE_TABLE_NLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Log] (
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Application] [nvarchar](50) NOT NULL,
    [Logged] [datetime] NOT NULL,
    [Level] [nvarchar](50) NOT NULL,
    [Message] [nvarchar](max) NOT NULL,
    [Logger] [nvarchar](250) NULL,
    [Callsite] [nvarchar](max) NULL,
    [Exception] [nvarchar](max) NULL,
  CONSTRAINT [PK_dbo.Log] PRIMARY KEY CLUSTERED ([Id] ASC)
    WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TABLE [dbo].[Log]");
        }
    }
}
