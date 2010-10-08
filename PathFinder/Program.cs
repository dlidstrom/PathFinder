// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder
{
   using System;
   using System.Windows.Forms;

   /// <summary>
   /// Main program class.
   /// </summary>
   public static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      private static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         // choose path finder by commenting below
         var mainForm = new MainForm(new AStarFactory());
         //var mainForm = new MainForm(new IdaFactory());

         Application.Run(mainForm);
      }
   }
}