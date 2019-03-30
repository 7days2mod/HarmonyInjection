using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SDX.Compiler;

public class StompyGameManagerPatch : IPatcherMod
{
  public bool Patch(ModuleDefinition module)
  {
    return true;
  }

  public bool Link(ModuleDefinition gameModule, ModuleDefinition modModule)
  {
    var gameManager = gameModule.Types.First(d => d.Name == "GameManager");
    var awake = gameManager.Methods.First(d => d.Name == "Awake");
    var instructions = awake.Body.Instructions;
    var proc1 = awake.Body.GetILProcessor();

    var patchGameManager = modModule.Types.First(d => d.Name == "PatchGameManager");
    var gameModuleMethod = gameModule.Import(patchGameManager.Methods.First(d => d.Name == "RegisterHarmony"));
    
    proc1.InsertBefore(instructions[0], Instruction.Create(OpCodes.Call, gameModuleMethod));

    return true;
  }
}
