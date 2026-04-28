
-- Base de Datos

    CREATE DATABASE db_Gimnasio;
    GO

    USE db_Gimnasio;
    GO

    CREATE TABLE Tbl_TipoMembresia (
        CodigoTipoMembresia INT IDENTITY(1,1) PRIMARY KEY,
        Nombre VARCHAR(50),
        Descripcion VARCHAR(100),
        CostoMensual DECIMAL(10,2),
        DuracionMeses INT,
        Estado BIT,
        FechaCreacion DATETIME
    );
    GO

    CREATE TABLE Tbl_Entrenador (
        CodigoEntrenador INT IDENTITY(1,1) PRIMARY KEY,
        Nombre VARCHAR(100),
        Especialidad VARCHAR(100),
        Telefono VARCHAR(20),
        Estado BIT,
        FechaRegistro DATETIME
    );
    GO

    CREATE TABLE Tbl_Cliente (
        CodigoCliente INT IDENTITY(1,1) PRIMARY KEY,
        Nombre VARCHAR(100),
        Edad INT,
        Telefono VARCHAR(20),
        Estado BIT,
        FechaRegistro DATETIME
    );
    GO

    CREATE TABLE Tbl_Inscripcion (
        CodigoInscripcion INT IDENTITY(1,1) PRIMARY KEY,

        CodigoCliente INT,
        CodigoTipoMembresia INT,
        CodigoEntrenador INT,

        Meses INT,
        FechaInicio DATE,

        CostoMensual DECIMAL(10,2),
        CostoTotal DECIMAL(10,2),
        Descuento DECIMAL(10,2),
        SubTotal DECIMAL(10,2),
        Impuesto DECIMAL(10,2),
        TotalPagar DECIMAL(10,2),

    FOREIGN KEY (CodigoCliente) REFERENCES Tbl_Cliente(CodigoCliente),
    FOREIGN KEY (CodigoTipoMembresia) REFERENCES Tbl_TipoMembresia(CodigoTipoMembresia),
    FOREIGN KEY (CodigoEntrenador) REFERENCES Tbl_Entrenador(CodigoEntrenador)
    );
    GO

	Select * From Tbl_Inscripcion order by CodigoInscripcion asc;


-- Datos prueba

    INSERT INTO Tbl_TipoMembresia VALUES
    ('B�sica','Acceso limitado',100,1,1,GETDATE()),
    ('Premium','Acceso total',200,1,1,GETDATE()),
    ('Anual','Plan anual',1000,12,1,GETDATE()),
    ('Estudiantil','Descuento estudiante',80,1,1,GETDATE()),
    ('VIP','Entrenamiento personalizado',300,1,1,GETDATE());

    INSERT INTO Tbl_Entrenador VALUES
    ('Carlos P�rez','Pesas','55550101',1,GETDATE()),
    ('Ana L�pez','Cardio','55550202',1,GETDATE()),
    ('Luis Garc�a','Crossfit','55550303',1,GETDATE()),
    ('Sof�a Ram�rez','Yoga','55550404',1,GETDATE()),
    ('Jos� Morales','Funcional','55550505',1,GETDATE());

    INSERT INTO Tbl_Cliente VALUES
    ('Juan P�rez',25,'55551111',1,GETDATE()),
    ('Mar�a L�pez',30,'55552222',1,GETDATE()),
    ('Pedro D�az',28,'55553333',1,GETDATE()),
    ('Luc�a Torres',22,'55554444',1,GETDATE()),
    ('Carlos M�ndez',35,'55555555',1,GETDATE());

    INSERT INTO Tbl_Inscripcion VALUES
    (1,1,1,2,'2025-04-01',100,200,0,200,24,224),
    (2,2,2,6,'2025-04-02',200,1200,120,1080,129.6,1209.6),
    (3,3,3,1,'2025-04-03',1000,1000,0,1000,120,1120),
    (4,4,4,8,'2025-04-04',80,640,64,576,69.12,645.12),
    (5,5,5,3,'2025-04-05',300,900,0,900,108,1008);

    -- Querys Crud

	-- Listar
	SELECT 
		CodigoInscripcion,
		CodigoCliente,
		CodigoTipoMembresia,
		CodigoEntrenador,
		Meses,
		FechaInicio,
		CostoMensual,
		CostoTotal,
		Descuento,
		SubTotal,
		Impuesto,
		TotalPagar
	FROM Tbl_Inscripcion;

	-- Agregar
	INSERT INTO Tbl_Inscripcion
	(
		CodigoCliente,
		CodigoTipoMembresia,
		CodigoEntrenador,
		Meses,
		FechaInicio,
		CostoMensual,
		CostoTotal,
		Descuento,
		SubTotal,
		Impuesto,
		TotalPagar
	)
	VALUES
	(
		@CodigoCliente,
		@CodigoTipoMembresia,
		@CodigoEntrenador,
		@Meses,
		@FechaInicio,
		@CostoMensual,
		@CostoTotal,
		@Descuento,
		@SubTotal,
		@Impuesto,
		@TotalPagar
	);

	-- Actualizar
	UPDATE Tbl_Inscripcion
	SET
		CodigoCliente = @CodigoCliente,
		CodigoTipoMembresia = @CodigoTipoMembresia,
		CodigoEntrenador = @CodigoEntrenador,
		Meses = @Meses,
		FechaInicio = @FechaInicio,
		CostoMensual = @CostoMensual,
		CostoTotal = @CostoTotal,
		Descuento = @Descuento,
		SubTotal = @SubTotal,
		Impuesto = @Impuesto,
		TotalPagar = @TotalPagar
	WHERE CodigoInscripcion = @CodigoInscripcion;
	?? ? DELETE

	-- Eliminar
	DELETE FROM Tbl_Inscripcion
	WHERE CodigoInscripcion = @CodigoInscripcion;

	-- Buscar
	SELECT 
		CodigoInscripcion,
		CodigoCliente,
		CodigoTipoMembresia,
		CodigoEntrenador,
		Meses,
		FechaInicio,
		CostoMensual,
		CostoTotal,
		Descuento,
		SubTotal,
		Impuesto,
		TotalPagar
	FROM Tbl_Inscripcion
	WHERE CodigoInscripcion = @CodigoInscripcion;



