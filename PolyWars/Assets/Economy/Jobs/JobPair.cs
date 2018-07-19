public unsafe struct JobPair
{
    public float amount;

    public BuildingInstance* exporter;
    public byte resourceIndexExporter;

    public BuildingInstance* importer;
    public byte resourceIndexImporter;
}