const PROXY_CONFIG = [
  {
    context: [
      '/odata/movie','/api/movie'
    ],
    target: "https://localhost:7051",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
