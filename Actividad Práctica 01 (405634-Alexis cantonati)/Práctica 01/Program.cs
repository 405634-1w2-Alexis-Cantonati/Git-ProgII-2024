// See https://aka.ms/new-console-template for more information
using Práctica_01.Dominio;
using Práctica_01.Servicios;

Console.WriteLine("Hello, World!");

FacturaManager ManagerF = new FacturaManager();

ManagerF.Borrar(1);

Factura factura = new Factura(1,new DateTime(2010,12,12),1,"adam");


ArticuloManager manager = new ArticuloManager();
Articulo articulo = new Articulo(1, "pelota", 20000);
manager.CrearArticulo(articulo);
DetalleFactura detalle = new DetalleFactura(1,1,articulo,78);
factura.AgregarDetalle(detalle);

ManagerF.CrearFactura(factura);
Console.WriteLine(ManagerF.TraerTodos());



