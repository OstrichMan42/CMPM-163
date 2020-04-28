uniform sampler2D texture1;
varying vec2 vUv;

float map(float value, float min1, float max1, float min2, float max2) {
  return min2 + (value - min1) * (max2 - min2) / (max1 - min1);
}

void main() {
	// sample from the texture based on the uv coordinates
	vec2 tiledUv;
	tiledUv.x = mod(vUv.x, 0.5) * 2.0;
	tiledUv.y = mod(vUv.y, 0.5) * 2.0;

	gl_FragColor = texture2D(texture1, tiledUv);
}

