using UnityEngine;
using System.Collections;

public class ShipsTab : Tab {

  public ShipsTab(StationMenu s) : base(s) {}

  public override void render() {
    if (GUILayout.Button("Ship 1")) {
      buy(GlobalPrefabs.find.ship1);
    }
    if (GUILayout.Button("Ship 2")) {
      buy(GlobalPrefabs.find.ship2);
    }
    if (GUILayout.Button("Ship 3")) {
      buy(GlobalPrefabs.find.ship3);
    }
  }

  private void buy(Transform ship) {
    if (PlayerData.credits >= ShipHelper.cost(ship)) {
      PlayerData.credits -= ShipHelper.cost(ship) - salvage_value();
      PlayerData.ship = ship;
    }
  }

  private int salvage_value() {
    return ShipHelper.cost(PlayerData.ship) / 2;
  }
}
