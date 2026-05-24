/*
drop table resultados
drop table execucoes
drop table planocasos
drop table planos
drop table passos
drop table casos
drop table nodes
drop table projetos
*/

CREATE TABLE projetos (
    id UUID PRIMARY KEY,
    nome VARCHAR(255) NOT NULL DEFAULT '',
    descricao TEXT,
    inativo BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMP DEFAULT NOW()
)

CREATE TABLE nodes (
    id UUID PRIMARY KEY,
    projeto_id UUID NOT NULL REFERENCES projetos(id) ON DELETE CASCADE,
    parent_id UUID NULL,
    nome VARCHAR(255) NOT NULL DEFAULT '',
    tipo VARCHAR(50) NOT NULL DEFAULT '',
    ordem INT DEFAULT 0,
	inativo BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMP DEFAULT NOW()
)

CREATE TABLE casos (
    id UUID PRIMARY KEY,
    node_id UUID NOT NULL REFERENCES nodes(id) ON DELETE CASCADE,
    pre_condicoes TEXT DEFAULT '',
    resultado_esperado TEXT DEFAULT '',
    created_at TIMESTAMP DEFAULT NOW()
)

CREATE TABLE passos (
    id UUID PRIMARY KEY,
    caso_id UUID NOT NULL REFERENCES casos(id) ON DELETE CASCADE,
	
    ordem INT NOT NULL,
    acao TEXT NOT NULL DEFAULT '',
    resultado_esperado TEXT DEFAULT '',
    created_at TIMESTAMP DEFAULT NOW()
)

CREATE TABLE planos (
    id UUID PRIMARY KEY,
    projeto_id UUID NOT NULL REFERENCES projetos(id) ON DELETE CASCADE,	
    nome VARCHAR(255) NOT NULL DEFAULT '',
    descricao TEXT NOT NULL DEFAULT '',
    created_at TIMESTAMP DEFAULT NOW()
)

CREATE TABLE planocasos (
    id UUID PRIMARY KEY,
	planos_id UUID NOT NULL REFERENCES planos(id) ON DELETE CASCADE,
    casos_id UUID NOT NULL REFERENCES casos(id) ON DELETE CASCADE,
    created_at TIMESTAMP DEFAULT NOW(),
    CONSTRAINT unique_plano_caso UNIQUE (planos_id, casos_id)
)

CREATE TABLE execucoes (
    id UUID PRIMARY KEY,
    plano_id UUID NOT NULL REFERENCES planos(id) ON DELETE CASCADE,
    executado_por VARCHAR(100) DEFAULT '', 
    data_execucao TIMESTAMP DEFAULT NOW(),
    status VARCHAR(20) DEFAULT '',
    created_at TIMESTAMP DEFAULT NOW()
)

CREATE TABLE resultados (
    id UUID PRIMARY KEY,
    execucao_id UUID NOT NULL REFERENCES execucoes(id) ON DELETE CASCADE,
	casos_id UUID NOT NULL,
    status VARCHAR(20) DEFAULT '',
    comentario TEXT DEFAULT '',
    created_at TIMESTAMP DEFAULT NOW()
)
