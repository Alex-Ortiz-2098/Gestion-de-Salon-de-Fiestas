# 🥂 Sistema de Gestión de Eventos y Reservas

Aplicación de consola desarrollada para la administración integral de un Salón de Fiestas. El sistema permite gestionar el ciclo de vida de un evento, desde la contratación de servicios y asignación de personal, hasta la facturación y manejo de cancelaciones.

## 📋 Características Principales

### 1. Gestión de Recursos
* **Servicios:** ABM (Alta, Baja, Modificación) de servicios disponibles (Catering, DJ, Mozos, etc.) con control de costos unitarios.
* **Personal:** Administración de empleados con **Herencia** aplicada:
  * **Empleado Base:** Sueldo, legajo y tareas generales.
  * **Encargado:** Extiende de Empleado, con responsabilidades de organización y cobro de plus salarial.

### 2. Motor de Reservas
* **Unicidad de Fecha:** El sistema valida que no existan dos eventos en la misma fecha y hora. En caso de conflicto, se dispara una **Excepción Personalizada** impidiendo la reserva.
* **Asignación:** Vinculación automática de un Encargado al confirmar la reserva.

### 3. Lógica de Negocio y Facturación
* **Cálculo de Costos:** Generación automática del costo total basándose en la lista de servicios contratados y sus cantidades.
* **Política de Cancelación:** Algoritmo que determina el reintegro de la seña basándose en la fecha de cancelación:
  * *Más de 1 mes de anticipación:* Se retiene la seña.
  * *Menos de 1 mes:* Se cobra el servicio completo.

### 4. Reportes
* Listados detallados de eventos, cartera de clientes y nómina de empleados.
* Filtrado de eventos por mes calendario.

## 🛠️ Tecnologías y Conceptos Aplicados
* **Lenguaje:** C# (.NET)
* **Paradigma:** Programación Orientada a Objetos (POO).
* **Conceptos Clave:**
  * **Herencia y Polimorfismo** (Clase `Encargado` hereda de `Empleado`).
  * **Encapsulamiento** de datos del cliente y evento.
  * **Manejo de Excepciones** (`try/catch`) para reglas de negocio.
  * **Manejo de Fechas** (`DateTime`) para cálculos de plazos.

---
*Proyecto académico desarrollado por Alex Ortiz.*
