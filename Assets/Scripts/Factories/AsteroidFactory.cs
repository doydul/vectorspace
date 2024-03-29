using UnityEngine;
using System.Collections;

public class AsteroidFactory : Factory {

  private const float min_scale = 0.8f;
  private const float max_roid_spin = 200;

  public static void make(float distance, float max_scale, Vector2 center) {
    add_new_roid_at(max_scale, TrigHelper.random_location(center, distance));
  }

  private static void add_new_roid_at(float max_scale, Vector2 position) {
    var asteroid_transform = GameObject.Instantiate(GlobalPrefabs.find.asteroid) as Transform;
    asteroid_transform.parent = GlobalObjects.foreground;
    asteroid_transform.localPosition = new Vector3(position.x, position.y, 0);

    var x_scale = Random.value * (max_scale - min_scale) + min_scale;
    var y_scale = Random.value * (max_scale - min_scale) + min_scale;
    asteroid_transform.localScale = new Vector2(x_scale, y_scale);
    asteroid_transform.GetComponent<Rigidbody2D>().mass *= x_scale * y_scale;

    asteroid_transform.GetComponent<Rigidbody2D>().angularVelocity = Random.value * max_roid_spin * 2 - max_roid_spin;

    Vector2 new_roid_velocity = new Vector2(Random.value * 4 - 2, Random.value * 4 - 2);
    asteroid_transform.GetComponent<Rigidbody2D>().velocity = new_roid_velocity;
  }
}
