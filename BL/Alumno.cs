using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.TEST_IrisEspindolaEntities context = new DL.TEST_IrisEspindolaEntities())
                {
                    var query = context.AlumnoAdd(alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.Email, alumno.Telefono, alumno.Password);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.TEST_IrisEspindolaEntities context = new DL.TEST_IrisEspindolaEntities())
                {
                    var query = context.AlumnoUpdate(alumno.IdAlumno,alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.Email, alumno.Telefono, alumno.Password);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TEST_IrisEspindolaEntities context = new DL.TEST_IrisEspindolaEntities())
                {
                    var query = context.AlumnoDelete(alumno.IdAlumno);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return (result);
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TEST_IrisEspindolaEntities context = new DL.TEST_IrisEspindolaEntities())
                {
                    var query = context.AlumnoGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = obj.IdAlumno;
                            alumno.Nombre = obj.Nombre;
                            alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            alumno.ApellidoMaterno = obj.ApellidoMaterno;
                            alumno.Email = obj.Email;
                            alumno.Telefono = obj.Telefono;
                            alumno.Password = obj.Password;
                            
                           
                            

                            result.Objects.Add(alumno);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TEST_IrisEspindolaEntities context = new DL.TEST_IrisEspindolaEntities())
                {
                    var obj = context.AlumnoGetById(IdAlumno).FirstOrDefault();
                    //result.Objects = new List<object>();
                    if (obj != null)
                    {
                        ML.Alumno alumno = new ML.Alumno();
                        alumno.IdAlumno = obj.IdAlumno;
                        alumno.Nombre = obj.Nombre;
                        alumno.ApellidoPaterno = obj.ApellidoPaterno;
                        alumno.ApellidoMaterno = obj.ApellidoMaterno;
                        alumno.Email = obj.Email;
                        alumno.Telefono = obj.Telefono;
                        alumno.Password = obj.Password;


                        result.Object = alumno;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
