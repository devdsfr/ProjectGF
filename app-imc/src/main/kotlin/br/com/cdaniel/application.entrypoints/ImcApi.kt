@RestContoller
class ImcApi(val imc:ImcUsecase){


	@PostMapping("/imc")
	fun imc(@Valid @RequestBody imcRequest: ImcRequest): RequestEntity<ImcResponse>{

		return ResponseEntity.ok(imc.calcule(imcRequest.height!!, imcRequest.weight!!))
	}
}
