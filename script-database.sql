CREATE TABLE projetos (
    id UUID PRIMARY KEY,
    nome VARCHAR(255) NOT NULL DEFAULT '',
    descricao TEXT,
    inativo BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMP DEFAULT NOW()
)

CREATE TABLE casos_nos (
    id UUID PRIMARY KEY,
    projeto_id UUID NOT NULL REFERENCES projetos(id) ON DELETE CASCADE,
    parent_id UUID NULL,
    nome VARCHAR(255) NOT NULL DEFAULT '',
    caso_teste BOOLEAN NOT NULL DEFAULT FALSE,
    ordem INT DEFAULT 0,
	inativo BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMP DEFAULT NOW()
)

CREATE TABLE casos_teste (
    id UUID PRIMARY KEY,
    casos_nos_id UUID NOT NULL,
    pre_condicoes TEXT DEFAULT '',
    resultado_esperado TEXT DEFAULT ''
)

CREATE TABLE passos_teste (
    id UUID PRIMARY KEY,
    casos_teste_id UUID NOT NULL REFERENCES casos_teste(id) ON DELETE CASCADE,
	
    ordem INT NOT NULL,
    acao TEXT NOT NULL DEFAULT '',
    resultado_esperado TEXT DEFAULT ''
)

CREATE TABLE planos_teste (
    id UUID PRIMARY KEY,
    projeto_id UUID NOT NULL REFERENCES projetos(id) ON DELETE CASCADE,	
    nome VARCHAR(255) NOT NULL DEFAULT '',
    descricao TEXT NOT NULL DEFAULT '',
    created_at TIMESTAMP DEFAULT NOW()
)

CREATE TABLE plano_casos (
    id UUID PRIMARY KEY,
	planos_teste_id UUID NOT NULL REFERENCES planos_teste(id) ON DELETE CASCADE,
    casos_teste_id UUID NOT NULL REFERENCES casos_teste(id) ON DELETE CASCADE,	
    CONSTRAINT unique_plano_caso UNIQUE (planos_teste_id, casos_teste_id)
)

CREATE TABLE execucoes (
    id UUID PRIMARY KEY,
    plano_id UUID NOT NULL REFERENCES planos_teste(id) ON DELETE CASCADE,
    executado_por VARCHAR(100) DEFAULT '', 
    data_execucao TIMESTAMP DEFAULT NOW(),
    status VARCHAR(20) DEFAULT ''
)

CREATE TABLE resultados (
    id UUID PRIMARY KEY,
    execucao_id UUID NOT NULL REFERENCES execucoes(id) ON DELETE CASCADE,
	casos_teste_id UUID NOT NULL,
    status VARCHAR(20) DEFAULT '',
    comentario TEXT DEFAULT ''
)
