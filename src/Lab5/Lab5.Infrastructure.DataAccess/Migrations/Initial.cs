using System;
using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type operation_type as enum
        (
            'create_account',
            'put_money',
            'withdraw_money'
        );

        create table customers
        (
            number char(16) primary key ,
            pin_code char(4) not null ,
            balance int not null 
        );

        create table admins
        (
            login varchar(20) primary key ,
            password varchar(50) not null
        );

        create table operations_history
        (
            operation_id bigint primary key generated always as identity ,
            customer_number char(16) not null references customers(number) ,
            operation operation_type not null ,
            new_balance int not null
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table customers;
        drop table admins;
        drop table operations_history;

        drop type operation_type;
        """;
}