﻿using CollectorsAnxiety.Util;
using ImGuiScene;
using Lumina.Excel.GeneratedSheets;

namespace CollectorsAnxiety.Data.Unlockables; 

public class OrchestrionEntry : DataEntry<Orchestrion> {
    public OrchestrionEntry(Orchestrion excelRow) : base(excelRow) {
        this.UnlockItem = CollectorsAnxietyPlugin.Instance.UnlockItemCache.GetItemForObject(excelRow);
    }
    
    public override string Name => this.LuminaEntry.Name.RawString.ToTitleCase();
    
    public override TextureWrap? Icon => 
        CollectorsAnxietyPlugin.Instance.IconManager.GetIconTexture(25945);

    public override Item? UnlockItem { get; }

    public override bool IsUnlocked() {
        return CollectorsAnxietyPlugin.Instance.GameState.IsOrchestrionUnlocked(this.Id);
    }

    public override bool IsValid() {
        return this.Id > 0 && this.Name != "";
    }
}