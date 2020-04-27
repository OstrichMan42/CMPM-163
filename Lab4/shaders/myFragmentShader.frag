varying vec3 vUv;
uniform vec3 colorA;
uniform vec3 colorB;
uniform vec3 colorC;

void main() {

	if (vUv.y > 0.6) {
		gl_FragColor = vec4(colorA, 1.0);
	} else if (vUv.x > 0.0) {
		gl_FragColor = vec4(colorB, 1.0);
	} else if (vUv.z < 0.5) {
		gl_FragColor = vec4(colorC, 1.0);
	} else {
		gl_FragColor = vec4(mix(colorA, colorB, vUv.z), 1.0);
	}
}
