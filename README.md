# Sqlzor

## Docker Images

### Database Engines

|Server Type|Docker Command                            |DockerHub URL                                                          |
|-----------|------------------------------------------|-----------------------------------------------------------------------|
|Postgres   |docker pull postgres                      |[https://hub.docker.com/_/postgres](https://hub.docker.com/_/postgres) |
|MariaDB    |docker pull mariadb                       |[https://hub.docker.com/_/mariadb](https://hub.docker.com/_/mariadb)   |
|MySQL      |docker pull mysql                         |[https://hub.docker.com/_/mysql](https://hub.docker.com/_/mysql)       |
|SQL Server |docker pull mcr.microsoft.com/mssql/server|[https://hub.docker.com/_/microsoft-mssql-server](https://hub.docker.com/_/microsoft-mssql-server) |

### Sample Databases

|Database Name |Server Type|Docker Command                                     |DockerHub URL                                                                                            |
|--------------|-----------|---------------------------------------------------|---------------------------------------------------------------------------------------------------------|
|AdventureWorks|SQL Server |docker pull chriseaton/adventureworks              |[https://hub.docker.com/r/chriseaton/adventureworks](https://hub.docker.com/r/chriseaton/adventureworks) |
|AdventureWorks|SQL Server |docker pull heimirthor/adventureworksforpostgres_db|[https://hub.docker.com/r/heimirthor/adventureworksforpostgres_db](https://hub.docker.com/r/heimirthor/adventureworksforpostgres_db) |
|Chinook       |MySQL      |docker pull myalenti/chinookdemo                   |[https://hub.docker.com/r/myalenti/chinookdemo](https://hub.docker.com/r/myalenti/chinookdemo)           |
|Chinook       |Postgres   |docker pull battlesable/chinook                    |[https://hub.docker.com/r/battlesable/chinook|](https://hub.docker.com/r/battlesable/chinook|)           |
|Northwind     |SQL Server |docker pull stackupiss/northwind-db                |[https://hub.docker.com/r/stackupiss/northwind-db](https://hub.docker.com/r/stackupiss/northwind-db)     |
|Northwind     |MySQL      |docker pull mcrcodes/northwind                     |[https://hub.docker.com/u/mcrcodes](https://hub.docker.com/u/mcrcodes)                                   |
|Northwind     |MySQL      |docker pull bylek/northwind-mysql                  |[https://hub.docker.com/r/bylek/northwind-mysql](https://hub.docker.com/r/bylek/northwind-mysql)         |

### DB Creation Scripts

|Database Name |Server Type                                       |URL                                                                                                          |
|--------------|--------------------------------------------------|-------------------------------------------------------------------------------------------------------------|
|Chinook       |MySQL, SQL Server, SQLite, PostgreSQL, Oracle, DB2|[https://github.com/lerocha/chinook-database](https://github.com/lerocha/chinook-database)                   |
|AdventureWorks|SQLite                                            |[https://github.com/nuitsjp/AdventureWorks-for-SQLite](https://github.com/nuitsjp/AdventureWorks-for-SQLite) |
|Northwind     |SQLLite                                           |[https://github.com/jpwhite3/northwind-SQLite3](https://github.com/jpwhite3/northwind-SQLite3)               |
