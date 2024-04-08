const cp = require('child_process');
const path = require('path');
const fs = require('fs');

// check if using docker or podman
const dockerExists = cp.spawnSync('which', ['docker']).status === 0;
const podmanExists = cp.spawnSync('which', ['podman']).status === 0;

if (dockerExists) {
    console.log('Using Docker');
} else if (podmanExists) {
    console.log('Using Podman');
} else {
    console.error('Neither Docker nor Podman found in $PATH');
    process.exit(1);
}

const cmd = dockerExists ? 'docker' : 'podman';

// get the docker container form the command line args
const args = process.argv.slice(2);
const containerArg = args.find(arg => arg.startsWith('--container='));
const container = containerArg ? containerArg.split('=')[1] : '';

const makefileArg = args.find(arg => arg.startsWith('--makefile='));
const makefile = makefileArg ? makefileArg.split('=')[1] : '';

if (!container) {
    console.error('No container specified');
    process.exit(1);
}

try{
cp.execSync(`${cmd} run -t -v ${path.join(__dirname,'..','microbe-c-sdl').split('\\').join('/')}:/app --rm ${container} make -f ./makefiles/${makefile}`, { stdio: 'inherit' });
}
catch (err){ 
  console.log("output", JSON.stringify(err,null,2));
}