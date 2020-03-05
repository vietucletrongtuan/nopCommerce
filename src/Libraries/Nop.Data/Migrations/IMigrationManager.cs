﻿using System;
using System.Reflection;
using FluentMigrator.Builders.Create;
using FluentMigrator.Expressions;

namespace Nop.Data.Migrations
{
    /// <summary>
    /// Represents a migration manager
    /// </summary>
    public interface IMigrationManager
    {
        /// <summary>
        /// Executes all found (and unapplied) migrations
        /// </summary>
        /// <param name="assembly">Assembly to find the migration;
        /// leave null to search migration on the whole application pull</param>
        /// <param name="tags">Migration tags for filtering</param>
        void ApplyUpMigrations(Assembly assembly, params string[] tags);

        /// <summary>
        /// Executes an Down migration
        /// </summary>
        /// <param name="assembly">Assembly to find the migration;
        /// leave null to search migration on the whole application pull</param>
        /// <param name="tags">Migration tags for filtering</param>
        void ApplyDownMigrations(Assembly assembly, params string[] tags);
        
        /// <summary>
        /// Retrieves expressions into ICreateExpressionRoot
        /// </summary>
        /// <param name="expressionRoot">The root expression for a CREATE operation</param>
        /// <typeparam name="TEntity">Entity type</typeparam>
        void BuildTable<TEntity>(ICreateExpressionRoot expressionRoot);

        /// <summary>
        /// Gets create table expression for entity type
        /// </summary>
        /// <param name="type">Entity type</param>
        /// <returns>Expression to create a table</returns>
        CreateTableExpression GetCreateTableExpression(Type type);
    }
}