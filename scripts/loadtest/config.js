var path = require("path");

module.exports = {
  runOptions: {
    url: "http://localhost:4001/api/person/${id}",
    method: "GET",
    loops: 1,
    ramp_time: 1,
    num_threads: 1200,
    stress_step: 0,
    stress_qty: 4,
    mass_data: path.resolve(__dirname, "mass.csv"),
  },
  jvmArgs: 'set JVM_ARGS="-Xms512m -Xmx4096m -Dpropname=value"',
  jmeterPath: "C:\\apps\\apache-jmeter-5.3\\bin\\",
};
