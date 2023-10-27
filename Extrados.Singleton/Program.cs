using Kioscos;


Kiosco miKiosco = Kiosco.Instance;

Usuario alan = new Usuario (1,"Alan",29);
Usuario lucas = new Usuario (2,"Lucas",34);
Usuario justin = new Usuario (3,"Justin",11);
Usuario sebastian = new Usuario (4,"Sebastian",17);
Usuario carlos = new Usuario (5,"Carlos",56);


Producto cervezaAndes = new Producto (1,"Andes Rubia",700,20,true,false);
Producto aguaMineral = new Producto (2, "agua manaos", 600, 20, false, true);
Producto Cigarrillos = new Producto (3, "Malboro", 900, 20, false, false);
Producto cervezaPatagonia = new Producto (4, "Patagonia weisse ", 800, 20, true, false);
Producto Cocacola = new Producto (5, "Cocacola", 1050, 20, false, true);

//miKiosco.EnVedaElectoral(true);

miKiosco.AgregarProducto(aguaMineral);
miKiosco.AgregarProducto(cervezaAndes);
miKiosco.AgregarProducto(Cigarrillos);
miKiosco.AgregarProducto(cervezaPatagonia);
miKiosco.AgregarProducto(Cocacola);
miKiosco.AgregarProducto(Cocacola);

var tareas = new List<Task>();

tareas.Add(Task.Run(() => miKiosco.Vender(aguaMineral, alan, 2, 2000)));
tareas.Add(Task.Run(() => miKiosco.Vender(cervezaAndes, lucas, 2, 2000)));
tareas.Add(Task.Run(() => miKiosco.Vender(cervezaAndes, justin, 2, 2000)));
tareas.Add(Task.Run(() => miKiosco.Vender(cervezaPatagonia, sebastian, 2, 2000)));
tareas.Add(Task.Run(() => miKiosco.Vender(Cigarrillos, carlos, 2, 2000)));

Task.WhenAll(tareas).Wait();

miKiosco.ProductosEnKiosco();
