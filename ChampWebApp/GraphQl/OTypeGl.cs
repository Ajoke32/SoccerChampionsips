using ChampWebApp.Models;

namespace ChampWebApp.GraphQl;

public class OTypeGl:ObjectType<Command>
{
   protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
   {
      descriptor.Field("node").UsePaging();
   }
}

