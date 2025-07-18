package br.com.projeto.ProjetoFinal.controller;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import br.com.projeto.ProjetoFinal.model.LoginModel;
import br.com.projeto.ProjetoFinal.model.UsuarioModel;
import br.com.projeto.ProjetoFinal.service.UsuarioService;

import jakarta.validation.Valid;
import java.util.List;

@RestController
@CrossOrigin("*")
@RequestMapping("/usuarios")
public class UsuarioController {

    private final UsuarioService usuarioService;

    public UsuarioController(UsuarioService usuarioService) {
        this.usuarioService = usuarioService;
    }

    @GetMapping
    public ResponseEntity<List<UsuarioModel>> listaUsuarios() {
        return ResponseEntity.ok(usuarioService.listarUsuario());
    }

    @PostMapping
    public ResponseEntity<UsuarioModel> criarUsuario(@Valid @RequestBody UsuarioModel usuario) {
        try {
            return ResponseEntity.status(HttpStatus.CREATED).body(usuarioService.criarUsuario(usuario));
        } catch (RuntimeException e) {
            return ResponseEntity.status(HttpStatus.CONFLICT).body(null);
        }
    }

    @PutMapping
    public ResponseEntity<UsuarioModel> editarUsuario(@Valid @RequestBody UsuarioModel usuario) {
        try {
            return ResponseEntity.ok(usuarioService.editarUsuario(usuario));
        } catch (RuntimeException e) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body(null);
        }
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deletarUsuario(@PathVariable Integer id) {
        usuarioService.deletarUsuario(id);
        return ResponseEntity.noContent().build();
    }

    @PostMapping("/login")
    public ResponseEntity<String> validarUsuario(@Valid @RequestBody LoginModel login) {
        boolean valid = usuarioService.validarUsuario(login.getEmail(), login.getSenha());
        if (!valid) {
            return ResponseEntity.status(HttpStatus.UNAUTHORIZED).body("Credenciais inválidas.");
        }
        return ResponseEntity.ok("Login realizado com sucesso!");
    }
}
