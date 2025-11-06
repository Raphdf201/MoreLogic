using Core.Localization;
using ShapezShifter.Flow;
using ShapezShifter.Flow.Atomic;
using ShapezShifter.Kit;
using ShapezShifter.Textures;
using ILogger = Core.Logging.ILogger;

namespace MoreLogic;

public class Main : IMod
{
    public Main(ILogger logger)
    {
        BuildingDefinitionGroupId groupId = new("MoreLogicGroup");
        BuildingDefinitionId nandDefId = new("NAND");

        const string nandTitleId = "building-variant.nand.title";
        const string nandDescriptionId = "building-variant.nand.description";

        var modResourcesLocator = ModDirectoryLocator.CreateLocator<Main>().SubLocator("Resources");

        using var assetBundleHelper = AssetBundleHelper.CreateForAssetBundleEmbeddedWithMod<Main>("Resources/bundle");
        
        var iconPath = modResourcesLocator.SubPath("icon.png");

        var groupBuilder = BuildingGroup.Create(groupId)
            .WithTitle(nandTitleId.T())
            .WithDescription(nandDescriptionId.T())
            .WithIcon(FileTextureLoader.LoadTextureAsSprite(iconPath, out _))
            .AsNonTransportableBuilding()
            .WithPreferredPlacement(DefaultPreferredPlacementMode.Single);
    }

    public void Dispose() {}
}