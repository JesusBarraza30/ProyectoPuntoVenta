﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta
{

    internal class Ventas
    {
        public Ventas()
        {

        }

        public Ventas(int idVenta, int idCliente, int idVendedor, decimal subtotal, decimal total, DateTime fechaVenta)
        {
            IdVenta = idVenta;
            IdCliente = idCliente;
            IdVendedor = idVendedor;
            Subtotal = subtotal;
            Total = total;
            FechaVenta = fechaVenta;
        }

        public Ventas(int idCliente, int idVendedor, decimal subtotal, decimal total, DateTime fechaVenta)
        {
            IdCliente = idCliente;
            IdVendedor = idVendedor;
            Subtotal = subtotal;
            Total = total;
            FechaVenta = fechaVenta;
        }

        public Ventas(int idVenta, int idCliente, int idVendedor, decimal subtotal, decimal total, DateTime fechaVenta, int id_producto, int cantidad)
        {
            IdVenta = idVenta;
            IdCliente = idCliente;
            IdVendedor = idVendedor;
            Subtotal = subtotal;
            Total = total;
            FechaVenta = fechaVenta;
            iDProducto = id_producto;
            Cantidad = cantidad;
        }

        public Ventas(int id_producto, int cantidad)
        {
            iDProducto = id_producto;
            Cantidad = cantidad;
        }

        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdVendedor { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaVenta { get; set; }
        public int iDProducto { get; set; }
        public int Cantidad { get; set; }

        public decimal GetTotalVenta()
        {
            double iva = (double)Subtotal * 0.16; ;
            decimal total = Subtotal + (decimal)iva;
            return total;
        }
    }
}