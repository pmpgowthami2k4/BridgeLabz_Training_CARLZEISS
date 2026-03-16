USE EMP1;
GO

CREATE TABLE Employee (
    EmpID INT PRIMARY KEY Identity(1,1),
    EmpName VARCHAR(50) NOT NULL ,
    Salary DECIMAL(10,2) CHECK(Salary >0) ,
    Department VARCHAR(50),
    JoinDate DATE DEFAULT GETDATE()
    
);  

INSERT INTO Employee (EmpID, EmpName, Salary, Department, JoinDate) VALUES
(1, 'Arun Kumar', 35000.00, 'HR', '2023-01-10'),
(2, 'Priya Sharma', 42000.50, 'Finance', '2022-11-15'),
(3, 'Rahul Verma', 50000.00, 'IT', '2021-09-20'),
(4, 'Sneha Reddy', 38000.75, 'Marketing', '2023-03-12'),
(5, 'Vikram Singh', 47000.00, 'Sales', '2022-07-18'),
(6, 'Anjali Mehta', 36000.00, 'HR', '2024-02-25'),
(7, 'Karan Patel', 55000.25, 'IT', '2021-12-05'),
(8, 'Neha Gupta', 41000.00, 'Finance', '2023-06-30'),
(9, 'Rohit Das', 39000.80, 'Marketing', '2022-04-14'),
(10, 'Pooja Nair', 45000.00, 'Sales', '2024-01-08');

SELECT EmpName, Salary
FROM Employee
WHERE Salary = (
    SELECT MAX(Salary)
    FROM Employee
    --max less the max
    WHERE Salary < (
        SELECT MAX(Salary)
        FROM Employee
    )
);


SELEct Department, COUNT(*) AS EmpCount
FROM Employee
WHERE Salary > (
    --AVG SAL OF THE DEPT
    SELECT AVG(Salary)
    FROM Employee AS E2
    WHERE E2.Department = Employee.Department
)

UPDATE Employee
SET JoinDate = '2024-01-01'
WHERE EmpID = 1;

--EMP WITH MAX EXPERIENCE
SELECT EmpName, DATEDIFF(YEAR, JoinDate, GETDATE()) AS Experience
FROM Employee
WHERE JoinDate = (
    SELECT MIN(JoinDate)
    FROM Employee
);


SELECT * from Employee

SELECT Department, EmpName
FROM Employee e
where JoinDate = (
SELECT MIN(JoinDate)
    FROM Employee
    where Department = e.Department
);

SELECT Department, EmpName
FROM Employee e
where JoinDate = (
SELECT MIN(JoinDate)
    FROM Employee
    where JoinDate = e.JoinDate
);

 
SELECT EmpName
FROM Employee
HAVING Salary > (
SELECT AVG(Salary) );

CREATE VIEW SecndHighestSal AS
SELECT * from Employee
where salary = (
    SELECT MAX(Salary)
    FROM Employee
    --max less the max
    WHERE Salary < (
        SELECT MAX(Salary)
        FROM Employee
    )
);


select * from SecndHighestSal

SELECT EmpName, Department, Salary
FROM Employee e
WHERE Salary = (
    SELECT MAX(Salary)
    FROM Employee
    WHERE Department = e.Department
);

----------------COMPUTED COLUMNS
CREATE TABLE salary_test
(
    ename VARCHAR(50),
    basic_salary INT,
    bonus INT,
    total_salary AS (basic_salary + bonus)
);

-------------COMPOSITE KEY
CREATE TABLE Orders (
    OrderID INT,
    ProductID INT,
    Quantity INT,
    PRIMARY KEY (OrderID, ProductID)
);


----------------------------snpshot
--CREATE DATABASE HR_Snapshot
--ON (NAME = HR, FILENAME = 'D:\snapshots\hr.ss')
--AS SNAPSHOT OF HR;

--RESTORE DATABASE HR
--FROM DATABASE_SNAPSHOT = 'HR_Snapshot';


------------------------function
CREATE FUNCTION AddNumbers (@num1 INT, @num2 INT)
RETURNS INT
AS
BEGIN
    DECLARE @result INT
    SET @result = @num1 + @num2
    RETURN @result
END

-----------------SCHEMA
--CREATE SCHEMA HR;