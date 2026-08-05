using System.Reflection;
using JetBrains.Annotations;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;

namespace WTTWAAC;

[Injectable(TypePriority = OnLoadOrder.Preload + 2), UsedImplicitly]
public class WAAC(WTTServerCommonLib.WTTServerCommonLib wttCommon) : IOnLoad
{
    public async Task OnLoadAsync(CancellationToken cancellationToken)
    {
        var assembly = Assembly.GetExecutingAssembly();
        await wttCommon.CustomClothingService.CreateCustomClothing(assembly);
        await wttCommon.CustomItemServiceExtended.CreateCustomItems(assembly);
        await wttCommon.CustomVoiceService.CreateCustomVoices(assembly);
        await wttCommon.CustomHeadService.CreateCustomHeads(assembly);
    }
}
