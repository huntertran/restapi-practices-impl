Design a pattern abiding RESTful API - A proof of concept
---

<!-- TOC -->

- [1. Abstract](#1-abstract)
- [2. How to run](#2-how-to-run)
    - [2.1. Prerequisition](#21-prerequisition)
    - [2.2. Setting up](#22-setting-up)
        - [2.2.1. Config database](#221-config-database)
        - [2.2.2. Config Postman](#222-config-postman)

<!-- /TOC -->

# 1. Abstract
<a id="markdown-abstract" name="abstract"></a>

REST APIs are nowadays the de-facto standard for Web applications. However, as more systems and services adapt REST architectural style, many problems arise regularly. To avoid these repetitive problems, developers could follow good practices and avoid bad practices. Thus, research on best and bad practices and how to design a simple but effective REST API is important. Yet, to the best of our knowledge, there are only a few concrete designs to recurring REST API practices, like "API Versioning". There are works on defining or detecting some practices, but not on designs to the practices. We present the most up-to-date list of REST API practices and propose designs, in the form of anti-patterns, to make a REST API compliant. We validate our anti-patterns with a survey and interviews of 55 developers.

This repository contains sample implementations of the patterns proposed in that research.

# 2. How to run
<a id="markdown-how-to-run" name="how-to-run"></a>

## 2.1. Prerequisition
<a id="markdown-prerequisition" name="prerequisition"></a>

* MySQL running
* Java 11
* .NET Core 3

## 2.2. Setting up
<a id="markdown-setting-up" name="setting-up"></a>

### 2.2.1. Config database
<a id="markdown-config-database" name="config-database"></a>

Run the commands in file `config\db.sql` to create the sample database, user, and table.

```sql
-- from config\db.sql file
create database db_example;
create user 'springuser'@'%' identified by 'ThePassword';
grant all on db_example.* to 'springuser'@'%';

-- generate required table
CREATE TABLE `db_example`.`Students` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  `Email` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC));
```

It should show something like this (if you use command line to setup and run mysql):

![mysql result](https://i.imgur.com/vgR3TCm.png)

Change the location of the hosted MySQL database in these files:

* dotnet/Utils/MyDbContext.cs
* javaspring/src/main/resources/application.properties

`20.151.2.26` is the IP address of the MySQL server. If you're hosting on the same machine, you can use `localhost`

### 2.2.2. Config Postman
<a id="markdown-config-postman" name="config-postman"></a>

You can just import the `configs/testing.postman_collection.json` file to your Postman to load all the test.