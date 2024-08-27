CREATE DATABASE MichellesBakery;
GO

USE MichellesBakery;
GO

CREATE TABLE Postres ( 
	IdPostre INT PRIMARY KEY IDENTITY,      
    Nombre VARCHAR(50) NOT NULL,      
	Descripcion VARCHAR(100) NOT NULL, 
    Precio DECIMAL(10, 2) NOT NULL,                 
    FechaVencimiento DATETIME NOT NULL,
	Estado BIT DEFAULT 1 NOT NULL,
	Stock INT NOT NULL,
	Calorias INT,
);
GO

INSERT INTO Postres (Nombre, Descripcion, Precio, FechaVencimiento, Estado, Stock, Calorias)
VALUES
('Pastel de Chocolate', 'Delicioso pastel de chocolate con cobertura de ganache.', 25.99, '2024-09-30', 1, 50, 400),

('Tarta de Manzana', 'Tarta casera de manzana con una base crujiente y canela.', 19.99, '2024-09-25', 1, 30, 300),

('Galletas de Avena', 'Galletas de avena suaves y esponjosas con pasas.', 12.50, '2024-10-05', 1, 100, 150),

('Brownies de Nueces', 'Brownies ricos en chocolate con trozos de nueces.', 22.00, '2024-09-15', 1, 20, 350),

('Cheesecake de Frutos Rojos', 'Cheesecake cremoso con una salsa de frutos rojos.', 27.50, '2024-10-01', 1, 25, 500);
GO