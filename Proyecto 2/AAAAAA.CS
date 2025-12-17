
								string respux;
								int cuenta=0;
								do
								{
									Console.WriteLine("Tenemos estos Servicios para Ofrecerle: ");
									Aura_Real.ImprimirListaServicios();
									Console.WriteLine("Ingrese el Nombre del que le gustaria contratar: ");
									string nomm= Console.ReadLine();
									
									foreach (Servicio x in Aura_Real.LISTA_SERVICIOS)
									{
										if(x.NOMBRE == nomm)
										{
											Console.WriteLine("Ingrese la cantidad que desea solicitar: ");
											int cantS= int.Parse(Console.ReadLine());
											int cantEmpT=Aura_Real.CantEmpleadoXTarea(nomm); // CANTIDAD DE PERSONAL DE UNA TAREA
											cuenta= x.CANTIDAD_PERSONAL*cantS;
											if(cuenta <= cantEmpT)
											{
												Servicio_Contratado ser1= new Servicio_Contratado(x,cantS);
												CostoServicios =CostoServicios + ser1.CalcularSubtotal();
												E1.AgregarServicoContratado(ser1);
												Aura_Real.AgregarEmpleadosEvento(cuenta,nomm,E1);
												
												Console.WriteLine("-----Agregado con Exito-----");
												break;
											}
											else
											{
												Console.WriteLine("Lo sentimos no tenemos la cantidad de empleados para el servicio solicitado");
												break;
											}
										}
										
									}
									
									
									Console.WriteLine("Desea ingresar otro Servicio:  ");
									respux= Console.ReadLine().ToLower();
									
								}while (respux == "s");
								
								float Totak= Aura_Real.PRECIO_BASE+CostoServicios;
								float sena;
								do{
									
									Console.WriteLine("Debe Ingresar señar (Mayor a 0 y Menor al total del evento): "+ Totak);
									sena= float.Parse(Console.ReadLine());
								
								}while(sena <= 0 && sena > Totak);
								E1.COSTO_TOTAL= Totak;
								E1.SENA= sena;
								
								Aura_Real.AgregaEvento(E1);
								Aura_Real.AgregarClientes(ClienteEvento1);
								Console.WriteLine("-----Agregado con Exito-----");
								break;
							}
						}
			
						catch FechaYaReservadaException ex;
						{
							Console.WriteLine(ex.Message);
						}
						break;
					case "F":