import typescript from '@rollup/plugin-typescript';
import json from '@rollup/plugin-json'
export default {
  input: './src/index.ts',
  output: {
    dir: './bin',
    format: 'es'
  },
  plugins: [typescript(),json()]
};