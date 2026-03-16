use DB1
go

CREATE TABLE dept (
    deptno INT NOT NULL PRIMARY KEY,
    dname VARCHAR(14) NOT NULL,
    loc VARCHAR(13) NOT NULL
);


CREATE TABLE emp (
    empno INT NOT NULL PRIMARY KEY,
    ename VARCHAR(10) NOT NULL,
    job VARCHAR(9) NOT NULL,
    mgr INT NULL,
    hiredate DATE NOT NULL,
    sal DECIMAL(7,2) NOT NULL,
    comm DECIMAL(7,2) NULL,
    deptno INT NOT NULL,

    CONSTRAINT fk_deptno FOREIGN KEY (deptno) 
        REFERENCES dept(deptno),

    CONSTRAINT fk_mgr FOREIGN KEY (mgr) 
        REFERENCES emp(empno)
);

--------------------------------
INSERT INTO dept VALUES (10, 'ACCOUNTING', 'NEW YORK');
INSERT INTO dept VALUES (20, 'RESEARCH', 'DALLAS');
INSERT INTO dept VALUES (30, 'SALES', 'CHICAGO');
INSERT INTO dept VALUES (40, 'OPERATIONS', 'BOSTON');

SELECT * FROM dept;

INSERT INTO emp VALUES (7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10);

INSERT INTO emp VALUES (7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30);

INSERT INTO emp VALUES (7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10);

INSERT INTO emp VALUES (7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20);

INSERT INTO emp VALUES (7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20);

INSERT INTO emp VALUES (7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20);

INSERT INTO emp VALUES (7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20);

INSERT INTO emp VALUES (7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30);

INSERT INTO emp VALUES (7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30);

INSERT INTO emp VALUES (7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30);

INSERT INTO emp VALUES (7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30);

INSERT INTO emp VALUES (7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20);

INSERT INTO emp VALUES (7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30);

INSERT INTO emp VALUES (7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10);

SELECT * FROM emp;

select ename,sal,comm, (sal + ISNULL(comm,100)) 
from emp

select * from emp 
where comm is null;
-----------------------------DDL

ALTER TABLE emp
ALTER COLUMN ename VARCHAR(20);


--------------------------DML

UPDATE emp
SET sal = 1000
WHERE ename = 'SMITH';

---DELETE FROM emp
---WHERE ename = 'SMITH';

----------------------TCL
BEGIN TRANSACTION;

UPDATE emp
SET sal = sal + 500
WHERE ename = 'SMITH';

COMMIT;
SELECT ename, sal FROM emp WHERE ename='SMITH';


BEGIN TRANSACTION;

UPDATE emp
SET sal = 2000
WHERE ename = 'SMITH';

ROLLBACK;
SELECT ename, sal FROM emp WHERE ename='SMITH';

------------------------DCL

CREATE LOGIN hruser 
WITH PASSWORD = 'Hr@123';

REVOKE UPDATE ON emp FROM hruser;
DROP LOGIN hruser;
-----------------------------

CREATE LOGIN hr
WITH PASSWORD = 'Hr@123';

use DB1

CREATE USER hr
FOR LOGIN hr;

GRANT UPDATE ON emp TO hr;

REVOKE UPDATE ON emp FROM hr;

-----CREATE LOGIN → CREATE USER → GRANT → REVOKE-------

------------------------------------------IN AND OR BETWEEN NOTIN

SELECT ename, deptno
FROM emp
WHERE deptno IN (10, 30);

SELECT ename, deptno
FROM emp
WHERE deptno NOT IN (10, 30);

SELECT ename, deptno
FROM emp
WHERE deptno BETWEEN 20 AND 30;

--------------------------------------foreign key
ALTER TABLE emp
ADD CONSTRAINT fk_dept
FOREIGN KEY (deptno)
REFERENCES dept(deptno);

-------------------WHERE GROUPBY HAVING ORDERBY

SELECT ename, sal
FROM emp
WHERE sal > 2000;

SELECT deptno, COUNT(*) AS total_employees
FROM emp
GROUP BY deptno;

SELECT deptno, COUNT(*) AS total
FROM emp
GROUP BY deptno
HAVING COUNT(*) > 3;

SELECT ename, sal
FROM emp
ORDER BY sal DESC;

SELECT job, COUNT(*)
FROM emp
WHERE sal > 1000
GROUP BY job
HAVING COUNT(*) > 1
ORDER BY job;

------------------CAST TRYCAST CONVERT
SELECT ename, CAST(sal AS INT) AS salary
FROM emp;

-----CONVERT(datatype, expression, style) 103=ddmmyyyy
SELECT CONVERT(VARCHAR, hiredate, 103)
FROM emp;

-------------------------JOINs
------inner join/ join
SELECT e.ename, d.dname
FROM emp e
JOIN dept d
ON e.deptno = d.deptno;

---left join
select e.ename, d.dname
from emp e
left join dept d
on e.deptno = d.deptno;

---right join
SELECT e.ename, d.dname
FROM emp e
RIGHT JOIN dept d
ON e.deptno = d.deptno;

----full join
SELECT e.ename, d.dname
FROM emp e
FULL JOIN dept d
ON e.deptno = d.deptno;

----cross join
select *
from emp e
cross join dept d;

-----self join
SELECT e.ename AS Employee,
       m.ename AS Manager
FROM emp e
JOIN emp m
ON e.mgr = m.empno;

------------------------CASE
SELECT ename, sal,
CASE
    WHEN sal > 3000 THEN 'High Salary'
    WHEN sal BETWEEN 1500 AND 3000 THEN 'Medium Salary'
    ELSE 'Low Salary'
END AS salary_category
FROM emp;

---------------------ROWNUMBER, RANK, PARITITION BY
SELECT 
ROW_NUMBER() OVER (ORDER BY sal DESC) AS row_num, 
ename, sal
FROM emp;

select 
rank() over (order by sal desc) as rank,
ename, sal
from emp;

SELECT ename, deptno, sal,
ROW_NUMBER() OVER (PARTITION BY deptno ORDER BY sal DESC) AS dept_rank
FROM emp;

---------------------CTE
WITH DeptSalary AS
(
    SELECT deptno, AVG(sal) AS avg_salary
    FROM emp
    GROUP BY deptno
)
SELECT *
FROM DeptSalary
WHERE avg_salary > 2000;

-----------------------------VIEWS
-------SIMPLE VIEW
CREATE VIEW emp_view
AS
SELECT empno, ename, job, sal
FROM emp;
SELECT * FROM emp_view;

-------COMPLEX VIEW
CREATE VIEW emp_dept_view
AS
SELECT e.ename, e.job, e.sal, d.dname, d.loc
FROM emp e
JOIN dept d
ON e.deptno = d.deptno;
SELECT * FROM emp_dept_view;

--------SCHEMA BINDING
CREATE VIEW emp_salary_view
WITH SCHEMABINDING
AS
SELECT empno, ename, sal
FROM dbo.emp;
SELECT * FROM emp_salary_view;

---------INDEXED VIEW
CREATE VIEW dept_total_salary
WITH SCHEMABINDING
AS
SELECT deptno, COUNT_BIG(*) AS emp_count, SUM(sal) AS total_sal
FROM dbo.emp
GROUP BY deptno;

CREATE UNIQUE CLUSTERED INDEX idx_dept_salary
ON dept_total_salary(deptno);

---DROP VIEW emp_view;

--------------------------------------LIKE
SELECT ename
FROM emp
WHERE ename LIKE '%A%';

-------------------------------TSQL
------IF ELSE
DECLARE @salary INT;

SELECT @salary = sal
FROM emp
WHERE ename = 'KING';

IF @salary > 3000
BEGIN
    PRINT 'High Salary';
END
ELSE
BEGIN
    PRINT 'Normal Salary';
END

-----IF EXISTS
IF EXISTS (SELECT * FROM emp WHERE ename = 'SMITH')
BEGIN
    PRINT 'Employee Exists';
END
ELSE
BEGIN
    PRINT 'Employee Not Found';
END

-------WHILE
DECLARE @count INT = 1;

WHILE @count <= 3
BEGIN
    UPDATE emp
    SET sal = sal + 100
    WHERE deptno = 10;

    SET @count = @count + 1;
END

---------------------TRIGGERS 
---dml insert delete and update
CREATE TRIGGER trg_emp_insert
ON emp
AFTER INSERT
AS
BEGIN
    PRINT 'New employee inserted';
END;

---dml create alter drop
CREATE TRIGGER trg_no_drop
ON DATABASE
FOR DROP_TABLE
AS
BEGIN
    PRINT 'Dropping tables is not allowed';
    ROLLBACK;
END;

---view triggers
--SELECT name
--FROM sys.triggers;

--DISABLE TRIGGER trg_emp_insert ON emp;
--ENABLE TRIGGER trg_emp_insert ON emp;
--DROP TRIGGER trg_emp_insert;


------------------------------------------PROCEDURES
CREATE PROCEDURE GetEmployees
AS
BEGIN
    SELECT * FROM emp;
END;

EXEC GetEmployees;

-------STORED PROCEDURE WITH PARAMETERS
CREATE PROCEDURE GetEmployeesByDept
    @deptno INT
AS
BEGIN
    SELECT * 
    FROM emp
    WHERE deptno = @deptno;
END;
EXEC GetEmployeesByDept 10;

------WITH MULTIPLE PARAMETERS
CREATE PROCEDURE GetEmployeeDetails
    @name VARCHAR(20),
    @dept INT
AS
BEGIN
    SELECT *
    FROM emp
    WHERE ename = @name
    AND deptno = @dept;
END;
EXEC GetEmployeeDetails 'KING', 10;

---------OUTPUT PARAMETERS
CREATE PROCEDURE GetSalary
    @name VARCHAR(20),
    @salary INT OUTPUT
AS
BEGIN
    SELECT @salary = sal
    FROM emp
    WHERE ename = @name;
END;

DECLARE @sal INT;

EXEC GetSalary 'KING', @sal OUTPUT;

SELECT @sal;

-------IF CONDITION
CREATE PROCEDURE CheckSalary
    @name VARCHAR(20)
AS
BEGIN
    DECLARE @salary INT;

    SELECT @salary = sal
    FROM emp
    WHERE ename = @name;

    IF @salary > 3000
        PRINT 'High Salary';
    ELSE
        PRINT 'Normal Salary';
END;

EXEC CheckSalary 'KING';

--DROP PROCEDURE GetEmployees;
------------------------------------subqueries
SELECT ename
FROM emp
WHERE deptno IN
(
    SELECT deptno
    FROM dept
    WHERE loc = 'DALLAS'
);

SELECT ename
FROM emp e
WHERE EXISTS
(
    SELECT *
    FROM dept d
    WHERE e.deptno = d.deptno
);


---correlated subquery
SELECT ename, sal, deptno
FROM emp e
WHERE sal >
(
    SELECT AVG(sal)
    FROM emp
    WHERE deptno = e.deptno
);


--Find employees whose salary is greater than ANY salary in department 1.
SELECT Name, Salary
FROM Employees
WHERE Salary > ANY
      (SELECT Salary FROM Employees WHERE DeptID = 1);



--Find employees whose salary is greater than ALL salaries in department 1.
SELECT column_name
FROM table_name
WHERE column_name operator ALL
      (SELECT column_name FROM table_name WHERE condition);