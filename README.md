# crud-players-app

_A small web application that uses angularjs, bootstrap, C# .NET and Web API._
## Installation

It is necessary install MySQL database;

The command to creates the database 'crudplayers':
```SQL
CREATE DATABASE crudplayers /*!40100 DEFAULT CHARACTER SET utf8 */;
```
The script to creates the table 'Player': 
```SQL
CREATE TABLE Player ( Id int(11) NOT NULL AUTO_INCREMENT, Name varchar(45) DEFAULT NULL, Club varchar(45) DEFAULT NULL, Country varchar(45) DEFAULT NULL, Age int(11) DEFAULT NULL, PictureUrl varchar(350) DEFAULT NULL, PRIMARY KEY (Id) ) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
```
When configuring the solution, it is necessary to install a nuget package for MySQL provider for database
