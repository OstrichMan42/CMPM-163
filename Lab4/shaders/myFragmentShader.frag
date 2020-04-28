uniform sampler2D texture1;
varying vec2 vUv;

void main() {
	// sample from the texture based on the uv coordinates
	vec2 tiledUv;
	tiledUv.x = mod(vUv.x, 0.5);
	tiledUv.y = mod(vUv.y, 0.5);
	gl_FragColor = texture2D(texture1, tiledUv);
}
