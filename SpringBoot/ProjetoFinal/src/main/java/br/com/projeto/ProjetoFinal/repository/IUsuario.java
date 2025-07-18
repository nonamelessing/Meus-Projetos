package br.com.projeto.ProjetoFinal.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import br.com.projeto.ProjetoFinal.model.UsuarioModel;

public interface IUsuario extends JpaRepository<UsuarioModel, Integer> {
    UsuarioModel findByEmail(String email);
}
