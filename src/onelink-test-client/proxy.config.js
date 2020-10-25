const PROXY_CONFIG = {
  '/employees/**': {
    target: 'http://localhost:5000/api/v1/',
    changeOrigin: true,
    secure: false,
    logLevel: 'debug',
  },
  '/characters/**': {
    target: 'https://sampleapis.com/futurama/api/',
    changeOrigin: true,
    secure: true,
    logLevel: 'debug',
  },
};

module.exports = PROXY_CONFIG;
