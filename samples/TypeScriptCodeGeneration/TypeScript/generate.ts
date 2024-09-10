import { generate } from "openapi-typescript-codegen";

process.env.NODE_TLS_REJECT_UNAUTHORIZED = "0";

generate({
  input: "https://localhost:7025/swagger/v1/swagger.json",
  output: "./src",
  exportSchemas: true,
  useOptions: true,
  useUnionTypes: true,
})
  .then(() => {
    console.log("Code generated successfully!");
  })
  .catch((e) => {
    console.log(e);
  });
