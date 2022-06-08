// See https://aka.ms/new-console-template for more information

Tareas();

void Tareas()
{
    Random random = new Random();
    List<Tarea> lTareasPendientes = new List<Tarea>();
    List<Tarea> lTareasRealizadas = new List<Tarea>();
    int cantidadTarea = 0;
    cantidadTarea = random.Next(1,10);

    for (int i = 0; i < 3; i++)
    {
        Tarea nTarea = new Tarea(lTareasPendientes.Count + 1);
        lTareasPendientes.Add(nTarea);
    }

    ConsoleKeyInfo op;
    Menu miMenu = new Menu();

    do
    {
        miMenu.DibujarMenu();
        op = Console.ReadKey();
        switch (op.Key)
        {
            case ConsoleKey.A:
                Console.Clear();
                MoverTareaAPendiente(ref lTareasPendientes, ref lTareasRealizadas);
                Console.ReadKey();
                break;
            case ConsoleKey.B:
                Console.Clear();
                TareaPendientePorDescrip(lTareasPendientes);
                Console.ReadKey();
                break;
            case ConsoleKey.C:
                Console.Clear();
                HorasTrabajadasPorEmpleado(lTareasRealizadas);
                Console.ReadKey();
                break;

        }
    } while (op.Key != ConsoleKey.F);
}

void MoverTareaAPendiente(ref List<Tarea> lTareasPendientes, ref List<Tarea> lTareasRealizadas)
{
    List<Tarea> auxTareasPendientes = new List<Tarea>();
    int resultado = 0;
    Console.WriteLine();
    Console.WriteLine("-----------Lista tareas pendientes----------");
    foreach (Tarea tarea in lTareasPendientes)
    {
        tarea.MostrarDatosTarea(); 

        Console.WriteLine("Terminaste ésta tarea? 1-si 2-no");
        resultado = int.Parse(Console.ReadLine());

        if (resultado == 1)
            lTareasRealizadas.Add(tarea);
        else
            auxTareasPendientes.Add(tarea);
    }

    lTareasPendientes = auxTareasPendientes;

}

void TareaPendientePorDescrip(List<Tarea> lTareas)
{
    Console.WriteLine("Ingrese la descripción de la tarea que buscas");
    string descripcion = Console.ReadLine();
    int encontrado = 0;

    foreach (Tarea tarea in lTareas)
    {
        if (tarea.GetDescripcion() == descripcion)
            tarea.MostrarDatosTarea();
        else
            encontrado++;
    }

    if(encontrado == lTareas.Count)
        Console.Write("La tarea con esa descripción no fue encontrada");
    
}

void HorasTrabajadasPorEmpleado(List<Tarea> lTareas)
{
    int Sumario = 0;
    foreach (Tarea tarea in lTareas)
    {
        Sumario += tarea.GetDuracion();
    }

    Console.WriteLine($"Horas trabajas por el empleado = {Sumario}");
}

class Tarea
{
    private int TareaId;
    private string Descripcion;
    private int Duracion;
    public Tarea(int idTarea)
    {
        TareaId = idTarea;
        Console.WriteLine($"---------[ /{TareaId}/ ]------------");
        
        do
        {
            Console.WriteLine("Ingresa la descripción");
            Descripcion = Console.ReadLine();
            setDescripcion(Descripcion);
        } while (Descripcion == "N");

        do
        {
            Console.WriteLine("Ingresa la duración de la tarea");
            Duracion = int.Parse(Console.ReadLine());
            SetDuracion(Duracion);
        } while (Duracion == 0);

        Console.WriteLine($"------------------------------------");

    }

    private void setDescripcion(string Descripcion)
    {
        if (!string.IsNullOrEmpty(Descripcion))
            this.Descripcion = Descripcion;
        else
            this.Descripcion = "N";
    }

    private void SetDuracion(int Duracion)
    {
        if (Duracion > 0)
            this.Duracion = Duracion;
        else
            this.Duracion = 0;
    }

    public string GetDescripcion()
    {
        return Descripcion;
    }
    public int GetDuracion()
    {
        return Duracion;
    }

    public void MostrarDatosTarea()
    {
        Console.WriteLine($"---------[{TareaId}]------------");
        Console.WriteLine("Id: " + TareaId.ToString());
        Console.WriteLine("Descripción: " + Descripcion);
        Console.WriteLine("Duración: " + Duracion.ToString());
        Console.WriteLine("---------------------------------");
    }
}
class Menu
{
    #region Metodos
    public void DibujarMenu()
    {
        Console.Clear();
        Console.WriteLine("*************************");
        Console.WriteLine("A- Mover tarea a pendiente\n");
        Console.WriteLine("B- buscar tareas pendientes por descripción\n");
        Console.WriteLine("C- sumario de las horas trabajadas por el empleado\n");
        Console.WriteLine("F- Salir\n");
        Console.WriteLine("*************************");
    }
    #endregion
}
