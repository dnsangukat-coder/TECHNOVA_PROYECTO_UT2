//------------------------------
//PROYECTO UT2:TECHNOVA-SOPORTE PERSONALIZADO
// Fase 1: Variable de sesión y menú principal

// Variable de sesión
int Totalincidencia = 0;
double recaudaciontotal = 0;
double importemaximo = 0 ;
string clientemaximo = "";
double caja = 0;
bool salir = false;

Console.WriteLine("       TECNOVA - GESTIÓN DE SOPORTE TÉCNICO       ");
Console.WriteLine("==================================================");

//2.BUCLE DEL MENÚ PRINCIPAL

while(!salir)
{
    Console.WriteLine("---MENÚ PRINCIPAL DE SOPORTE---");
    Console.WriteLine("1. Registrar Nueva incidencia de soporte técnico");
    Console.WriteLine("2. Consultar caja y estadistica de soporte");
      Console.WriteLine("3. Salir del sistema");
        Console.WriteLine("Selecciona una opción(1-3)");
    int opcionmenu =int.Parse(Console.ReadLine()?? "0");
    switch (opcionmenu)
    {
        case 1:
       //Día 2:DaTOS DEL CLIENTE
       {
       Console.WriteLine("----DATOS DEL CLIENTE ---");
        Console.WriteLine("Introduce el nombre del cliente:");
        string cliente = (Console.ReadLine()?? "").Trim();
while (cliente == "")
                {
                    Console.WriteLine("Error:el nombre no puede estar vacío.Inténtalo de nuevo:");
                    cliente = (Console.ReadLine()?? "").Trim();
                }
        //SELECCION DEL SERVICIO 
        int opcionservicio = 0;
        double Precio = 0;
        string nombreServicio = "";
        while (opcionservicio < 1 || opcionservicio > 3)
                {
                    
                
         Console.WriteLine("--- SERVICIO DE SOPORTE ---");
           Console.WriteLine("1. Instalacion de programas - 25 euros");
             Console.WriteLine("2. Configuracion del equipo - 20 euros");
               Console.WriteLine("3. Eliminacion de virus - 35 euros");
                 Console.WriteLine("Selecciona un servicio(1-3):");
                 opcionservicio = int.Parse(Console.ReadLine()??"0");
                 
          if(opcionservicio == 1)
            {
                Precio = 25 ;
              nombreServicio = "Instalacion de programas";
            }
            else if(opcionservicio == 2)
            {
                Precio = 20;
              nombreServicio = "Configuracion del equipo";
            }
else if(opcionservicio == 3)
            {
                Precio = 35 ;
                 nombreServicio = "Eliminacion de virus";
            }
                else
                {
                    Console.WriteLine(" Error: Servicio no valido. Intentalo de nuevo");
                  
                }
                }
                Console.WriteLine ("Servicio seleccionado: "+ nombreServicio + "(" + Precio.ToString("F2") + "euros)");
       // Día 3: Servicios extras
        bool extra1 = false;
        bool extra2 = false;
        bool extra3 = false;
        int cantidadextras = 0;
        double extra = 0 ;
        int opcionextra = -1;
        while (opcionextra != 0)
                {
                    
                
       Console.WriteLine("--- SERVICIOS EXTRA ---");
        Console.WriteLine("1. Copia de seguridad - 10 euros");
         Console.WriteLine("2. Limpieza - 8 euros");
          Console.WriteLine("3- Optimizacion del sistema - 12 euros");
           Console.WriteLine("0. Terminar seleccion extras");
              Console.WriteLine("Extras elegidos: " + cantidadextras + "| Importe extras" + extra.ToString("F2") + "euros");
        
           opcionextra = int.Parse(Console.ReadLine()?? "-1") ;

                if (opcionextra == 1)
                    {
                        if(extra1) Console.WriteLine("Ya has añadido la copia de seguridad");
                        else
                        {
                            extra1 = true; extra +=10; cantidadextras++; 
                        }
                    }
                
            


                
                else if(opcionextra == 2)
                {
                        if(extra2) Console.WriteLine("Ya has añadido la limpieza ");
                        else
                        {
                            extra2 = true; extra += 8; cantidadextras++; 
                        }
                    }

                else if(opcionextra == 3)
                 {
                        if(extra3) Console.WriteLine("Ya has añadido la optimizacion");
                        else
                        {
                            extra3= true; extra +=12; cantidadextras++; 
                        }
                    }

                else if(opcionextra != 0)
                {
                     Console.WriteLine("Extra no valido" );
                     
                }
                }
                // MODALIDAD
                int modalidad = 0;
                while (modalidad != 1 && modalidad != 2)
                    {
                        
                    
                 Console.WriteLine("--- MODALIDAD ---" );
                  Console.WriteLine("1. Normal(sin suplemento) " );
                  Console.WriteLine("2. Urgent(+15% suplemento)" );
                  modalidad =int.Parse(Console.ReadLine()?? "0");
                  if(modalidad != 1 && modalidad != 2)
                {
                    Console.WriteLine("Error: Modalidad no valida " );
                    
                }
                    

                    }
                // CALCULAR PRECIO  CON DESCUENTO Y SUPLEMENTO
                double subtotal = Precio + extra ;
                double descuento = 0;

                // Regla:10% de descuento si el subtotal supera los 40 euros
                if(subtotal > 40)
                    {
                        descuento = subtotal * 0.10;

                    }
                    double baseconDescuento = subtotal - descuento;
                    double suplemento = 0;
                if (modalidad == 2)
                {
                    suplemento = baseconDescuento * 0.15 ; 
                }
double importe = baseconDescuento +suplemento;
// DESGLOSE ANTES DEL COBRO
Console.WriteLine("------- DESGLOSE ANTES DEL COBRO ------");
          Console.WriteLine("Subtotal(servicio +extras):"  + subtotal.ToString("F2") + "euros");     
            Console.WriteLine("Descuento aplicado:"  + descuento.ToString("F2") + "euros"); 
              Console.WriteLine("Suplemento urgencia:"  + suplemento.ToString("F2") + "euros");  
                Console.WriteLine("TOTAL A PAGAR:"  + importe.ToString("F2") + "euros");                
                
                //DIA 4:FORMA DE PAGO
                int pago = 0;
while ( pago != 1 && pago != 2)
{
   Console.WriteLine("--------- FORMA DE PAGO ------" );
      Console.WriteLine("1. Efectivo" );
         Console.WriteLine("2. Tarjeta" );
         Console.WriteLine("Selecciona forma de pago(1-2):" );
         pago = int.Parse(Console.ReadLine()?? "0");
         if (pago != 1 && pago != 2)
                {
                       Console.WriteLine("Error:Pago no valido" );
                       
                }
}

double recibido = 0;
double cambio = 0;
if(pago == 1)
                {
                     Console.WriteLine("Introduce el dinero  recibido:" );  
                     recibido = double.Parse(Console.ReadLine()?? "0");
while(recibido < importe)
                {
                       Console.WriteLine("Dinero insuficiente. Introduca el importe completo de nuevo:" );
                         recibido = double.Parse(Console.ReadLine()?? "0");
                }

cambio = recibido - importe;
caja +=importe;


                }

                else
                {
                    recibido = importe;
                    cambio = 0;
                    Console.WriteLine("Pago realizado con tarjeta" );
                }


                //ACTUALIZAR ESTADISTICAS
                Totalincidencia++ ;
                recaudaciontotal = recaudaciontotal +importe ;
                if (importe > importemaximo)
                {
                    importemaximo = importe ;
                    clientemaximo = cliente ;
                }
    
           // MOSTRAR RESULTADO
           Console.WriteLine("--- RESUMEN ---" );
               Console.WriteLine("JUSTIFICANTE DE OPRACION" + Totalincidencia);
         
           Console.WriteLine("Cliente" + cliente );
           Console.WriteLine(" servicio:" + nombreServicio + "(" + Precio.ToString("F2") + "€)" );
           Console.WriteLine(" Extras (" + cantidadextras + ")" + extra.ToString("F2") + "€" );
           Console.WriteLine("Importe final:"+ importe.ToString("F2") + "euros" );
if(extra1) Console.WriteLine("  - Copia de seguridad");
if(extra2) Console.WriteLine("  - Limpieza interna");
if(extra3) Console.WriteLine("  - Optimizacion del sistema");
if(cantidadextras == 0) Console.WriteLine("  - Ninguno");

    Console.WriteLine("Modalidad:" + (modalidad == 1 ? "Normal" : "urgente") );
               Console.WriteLine(" Descuento:" + descuento.ToString("F2") + "€" );
 Console.WriteLine(" Suplemento:" + suplemento.ToString("F2") + "€" );
 Console.WriteLine(" TOTAL PAGADO:" + importe.ToString("F2") + "€" );
 Console.WriteLine(" Importe entrgado:" + recibido.ToString("F2") + "€" );
 Console.WriteLine(" Cambio devuelto:" + cambio.ToString("F2") + "€" );

           Console.WriteLine("Incidencia registrada correctamente" );
           break; 

       }



        case 2 :
   Console.WriteLine("---CAJA Y ESTADISTICAS---" );
   if(Totalincidencia == 0)
            {
                   Console.WriteLine("Todavia no hay incidencias registradas" );
            }
            else
            {
                   Console.WriteLine("Incidencias cobrada:" + Totalincidencia );
                   Console.WriteLine("Recaudación total: " + recaudaciontotal.ToString("F2") + " euros");
double media = recaudaciontotal / Totalincidencia;
 Console.WriteLine(" Importe medio por incidencia :" + recaudaciontotal.ToString("F2") + "€" );

                   Console.WriteLine("Dinero en caja: " + caja.ToString("F2") + " euros");
                   Console.WriteLine("Importe maximo: " + importemaximo.ToString("F2") + " euros");
                   Console.WriteLine("Cliente Con mayor importe: " + clientemaximo );
            }
break;

case 3 :
    Console.WriteLine("--- RESUMEN FINAL DE LA SESION ---" );
     Console.WriteLine(" Total incidencias cobradas:" + Totalincidencia );
      Console.WriteLine(" Recaudación total:" + recaudaciontotal.ToString("F2") + "€" );


   Console.WriteLine("Gracias por utilizar TECNOVA.Cerrando el sistema..." );

salir = true;

break;
default:
Console.WriteLine("Error: opción no valida. ");
break;
    
    }
    
    
} 