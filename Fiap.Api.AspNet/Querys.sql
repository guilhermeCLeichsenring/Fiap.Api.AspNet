CREATE TABLE t_area_de_risco (
    id_area_de_risco             NUMBER(4) NOT NULL,
    localizacao_area_de_risco    VARCHAR2(20) NOT NULL,
    nivel_rio_area_de_risco_cm   NUMBER(4, 2) NOT NULL,
    dt_ultimo_registro           DATE NOT NULL,
    t_rio_id_rio                NUMBER(4),
    t_pluviometro_id_pluviometro NUMBER(4) NOT NULL
);

 

ALTER TABLE t_area_de_risco ADD CONSTRAINT t_area_de_risco_pk PRIMARY KEY ( id_area_de_risco );

 

CREATE TABLE t_boia_monito (
    id_ferramenta          NUMBER(4) NOT NULL,
    localizacao_ferramenta NUMBER(5) NOT NULL,
    status_rio             VARCHAR2(50) NOT NULL,
    alerta_risco           CHAR(1) NOT NULL,
    dt_ultimo_registro     DATE NOT NULL,
    t_rio_id_rio           NUMBER(4) NOT NULL
);

 


ALTER TABLE t_boia_monito ADD CONSTRAINT t_ferramenta_monit_pk PRIMARY KEY ( id_ferramenta );

 

CREATE TABLE t_pluviometro (
    id_pluviometro     NUMBER(4) NOT NULL,
    nivel_chuva        NUMBER(5) NOT NULL,
    ds_pluviometro     CLOB,
    dt_ultimo_registro DATE NOT NULL
);

 

ALTER TABLE t_pluviometro ADD CONSTRAINT t_pluviometro_pk PRIMARY KEY ( id_pluviometro );

 

CREATE TABLE t_rio (
    id_rio                    NUMBER(4) NOT NULL,
    nm_rio                    VARCHAR2(50) NOT NULL,
    ds_rio                    CLOB NOT NULL
);

 

ALTER TABLE t_rio ADD CONSTRAINT t_rio_pk PRIMARY KEY ( id_rio );

 

--  ERROR: FK name length exceeds maximum allowed length(30) 
ALTER TABLE t_area_de_risco
    ADD CONSTRAINT t_area_de_risco_t_pluviometro_fk FOREIGN KEY ( t_pluviometro_id_pluviometro )
        REFERENCES t_pluviometro ( id_pluviometro );

 

ALTER TABLE t_area_de_risco
    ADD CONSTRAINT t_area_de_risco_t_rio_fk FOREIGN KEY ( t_rio_id_rio )
        REFERENCES t_rio ( id_rio );

 

ALTER TABLE t_boia_monito
    ADD CONSTRAINT t_boia_monito_t_rio_fk FOREIGN KEY ( t_rio_id_rio )
        REFERENCES t_rio ( id_rio );
