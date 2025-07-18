package br.com.projeto.ProjetoFinal.service;

import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;
import br.com.projeto.ProjetoFinal.model.UsuarioModel;
import br.com.projeto.ProjetoFinal.repository.IUsuario;

import java.util.List;

@Service
public class UsuarioService {

    private final IUsuario repository;
    private final PasswordEncoder passwordEncoder;

    public UsuarioService(IUsuario repository) {
        this.repository = repository;
        this.passwordEncoder = new BCryptPasswordEncoder();
    }

    public List<UsuarioModel> listarUsuario() {
        return repository.findAll();
    }

    public UsuarioModel criarUsuario(UsuarioModel usuario) {
        if (repository.findByEmail(usuario.getEmail()) != null) {
            throw new RuntimeException("Email já está em uso.");
        }
        usuario.setSenha(passwordEncoder.encode(usuario.getSenha()));
        return repository.save(usuario);
    }

    public UsuarioModel editarUsuario(UsuarioModel usuario) {
        if (repository.findByEmail(usuario.getEmail()) == null) {
            throw new RuntimeException("Usuário não encontrado.");
        }
        usuario.setSenha(passwordEncoder.encode(usuario.getSenha()));
        return repository.save(usuario);
    }

    public Boolean deletarUsuario(Integer id) {
        repository.deleteById(id);
        return true;
    }

    public Boolean validarUsuario(String email, String senha) {
        UsuarioModel usuario = repository.findByEmail(email);
        if (usuario == null) {
            return false;
        }
        return passwordEncoder.matches(senha.trim(), usuario.getSenha());
    }
}
