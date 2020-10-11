var path = require("path");

module.exports = {
  runOptions: {
    url: "http://localhost:4000/api/person/${id}",
    method: "GET",
    loops: 1,
    ramp_time: 1,
    num_threads: 200,
    stress_step: 100,
    stress_qty: 10,
    mass_data: path.resolve(__dirname, "mass.csv"),
  },
  jvmArgs: 'set JVM_ARGS="-Xms512m -Xmx4096m -Dpropname=value"',
  jmeterPath: "C:\\apps\\apache-jmeter-5.3\\bin\\",
};
